using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler ,IDraggableSlot,IDropHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;

    private InventoryController inventoryController;
    private int slotIndex;
    public InventoryItem currentItem {get; private set; }
    public SlotSourceType SourceType => SlotSourceType.Inventory;
    public void Bind(InventoryController controller, int index)
    {
        inventoryController = controller;
        slotIndex = index;
        var allItems = inventoryController.GetAllItems();
        
        if (slotIndex >= 0 && slotIndex < allItems.Count)
            currentItem = allItems[slotIndex];
        else
            currentItem = null;
        RefreshSlot();
    }

    public void SetSlot(ItemSO item, int quantity)
    {
        icon.sprite = item.icon;
        if(quantity!=1)quantityText.text = quantity.ToString();
        gameObject.SetActive(true);
        currentItem = inventoryController.GetItem(slotIndex);
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
            SetSlot(currentItem.itemData, currentItem.Quantity);
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
    
    public void OnDrop(PointerEventData eventData)
    { 
        IDraggableSlot draggedSlot = eventData.pointerDrag?.GetComponent<IDraggableSlot>();
        
        if (draggedSlot == null) return;

        if (draggedSlot is IDisplaySlot fromDisplaySlot)
        {
            inventoryController.displayController.ReturnToInventory(fromDisplaySlot.displayIndex);
        }
        
        draggedSlot.RefreshSlot();
        RefreshSlot();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        DragItemUI.Instance.EndDrag();
        RefreshSlot();
    }
    
}