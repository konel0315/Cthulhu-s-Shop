using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler ,IDraggableSlot,IDropHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;

    private InventoryController inventoryController;
    private DisplayController displayController;
    private HoldingAreaController holdingAreaController;
    
    public GameItem currentItem {get; private set; }
    public SlotSourceType SourceType => SlotSourceType.Inventory;
    public void Bind(InventoryController controller, DisplayController displayController,HoldingAreaController holdingAreaController)
    {
        inventoryController = controller;
        this.displayController= displayController;
        this.holdingAreaController= holdingAreaController;
        currentItem = null;
        RefreshSlot();
    }

    public void SetSlot(GameItem item)
    {
        currentItem = item;
        icon.sprite = item.itemData.icon;
        quantityText.text = item.Quantity > 1 ? item.Quantity.ToString() : "";
        gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        icon.sprite = Resources.Load<Sprite>("UI/인벤토리");
        quantityText.text = "";
        currentItem = null;
    }
    
    public void RefreshSlot()
    {
        if (currentItem != null)
            SetSlot(currentItem);
        else
            ClearSlot();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (currentItem == null)
        {
            return;
        }
        DragItemUI.Instance.BeginDrag(currentItem.itemData);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (currentItem != null)
            DragItemUI.Instance.UpdatePosition(eventData.position);
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        DragItemUI.Instance.EndDrag();
        RefreshSlot();
    }
    
    public void OnDrop(PointerEventData eventData)
    { 
        if (!DragItemUI.Instance.IsDragging())
            return;
        
        IDraggableSlot draggedSlot = eventData.pointerDrag?.GetComponent<IDraggableSlot>();
        
        if (draggedSlot == null) return;

        if (draggedSlot is IDisplaySlot fromDisplaySlot)
        {
            displayController.ReturnToInventory(fromDisplaySlot.displayIndex);
        }

        if (draggedSlot.SourceType == SlotSourceType.Taking)
        {
            holdingAreaController.ReturnTakingItemToInventory();
        }

        draggedSlot.RefreshSlot();
        RefreshSlot();
    }
    
}
