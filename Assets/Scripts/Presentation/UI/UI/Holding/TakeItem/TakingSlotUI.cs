using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TakingSlotUI : MonoBehaviour,IDraggableSlot,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;

    public GameItem currentItem {get; private set; }
    public SlotSourceType SourceType => SlotSourceType.Taking;

    private HoldingAreaController holdingAreaController;
    
    public void Bind(HoldingAreaController holdingAreaController)
    {
        this.holdingAreaController = holdingAreaController;
        
    }
    public void SetSlot(GameItem item)
    {
        currentItem = item;

        icon.sprite = item.itemData.icon;
        quantityText.text = item.Quantity > 1 ? item.Quantity.ToString() : "";
    }

    public void ClearSlot()
    {
        currentItem = null;
        
        icon.sprite = Resources.Load<Sprite>("UI/투명");
        quantityText.text = "";
    }

    public void RefreshSlot()
    {
        if (holdingAreaController.HasGiving) return;
        
        if (currentItem != null)
            SetSlot(currentItem);
        else
            ClearSlot();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (currentItem == null) return;
        
        DragItemUI.Instance.BeginDrag(currentItem.itemData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentItem == null) return;
        
        DragItemUI.Instance.UpdatePosition(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragItemUI.Instance.EndDrag();
        RefreshSlot();
    }
}