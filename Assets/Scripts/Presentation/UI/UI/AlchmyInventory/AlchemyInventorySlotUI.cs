using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AlchemyInventorySlotUI : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler,
    IDropHandler

{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;

    private AlchemyController alchemyController;
    
    public GameItem CurrentItem { get; private set; }

    public void Bind(InventoryController controller, AlchemyController alchemyController)
    {
        ClearSlot();
        this.alchemyController = alchemyController;
    }

    public void SetSlot(GameItem item)
    {
        CurrentItem = item;
        icon.sprite = item.itemData.icon;
        quantityText.text = item.Quantity > 1 ? item.Quantity.ToString() : "";
    }

    public void ClearSlot()
    {
        CurrentItem = null;
        icon.sprite = Resources.Load<Sprite>("UI/인벤토리");
        quantityText.text = "";
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CurrentItem == null) return;
        DragItemUI.Instance.BeginDrag(CurrentItem.itemData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragItemUI.Instance.UpdatePosition(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragItemUI.Instance.EndDrag();
    }

    public void OnDrop(PointerEventData eventData)
    {
        IDraggableSlot draggedSlot = eventData.pointerDrag.GetComponent<IDraggableSlot>();
        if (draggedSlot == null) return;
        if (draggedSlot.SourceType == SlotSourceType.AlchemyResult)
        {
            alchemyController.AcquireItem();
        }
        draggedSlot.RefreshSlot();
    }
}