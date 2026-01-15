using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

class HoldingSlotUI : MonoBehaviour,IDropHandler
{
    [SerializeField] private GameObject Root; 
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;


    private DisplayController displayController;
    private HoldingAreaController holdingAreaController;

    public void Bind(HoldingAreaController holdingAreaController,DisplayController displayController)
    {
        this.holdingAreaController = holdingAreaController;
        this.displayController = displayController;
    }

    public void SetSlot(ItemSO item, int quantity)
    {
        icon.sprite = item.icon;
        if(quantity!=1)quantityText.text = quantity.ToString();
        gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        icon.sprite = Resources.Load<Sprite>("UI/투명");
        quantityText.text = "";
    }


    public void RefreshSlot()
    {
        var currentItem = holdingAreaController.GetItem();
        if (holdingAreaController.GetItem() != null)
            SetSlot(currentItem.item, currentItem.quantity);
        else
            ClearSlot();
    }
    
    public void OnDrop(PointerEventData eventData)
    { 
        IDraggableSlot draggedSlot = eventData.pointerDrag?.GetComponent<IDraggableSlot>();
        
        if (draggedSlot == null) return;

        if (draggedSlot is IDisplaySlot fromDisplaySlot)
        {
            holdingAreaController.AddFromDisplay(displayController.GetItemAt(fromDisplaySlot.displayIndex),fromDisplaySlot.displayIndex);
        }
        else holdingAreaController.AddFromInventory(draggedSlot.currentItem.itemData, draggedSlot.currentItem.Quantity);
        draggedSlot.RefreshSlot();
        RefreshSlot();
    }

}