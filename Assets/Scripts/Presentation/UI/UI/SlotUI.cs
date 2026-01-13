using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;

    private InventoryController inventoryController;
    private int slotIndex;
    public InventoryItem currentItem {get; private set; }

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
        quantityText.text = quantity.ToString();
        gameObject.SetActive(true);
        currentItem = new InventoryItem(item, quantity);
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

    public void OnEndDrag(PointerEventData eventData)
    {
        DragItemUI.Instance.EndDrag();
        RefreshSlot();
    }
    
}