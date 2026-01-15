using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

class DisplaySlotUI : MonoBehaviour, IDropHandler,IBeginDragHandler, IDragHandler, IEndDragHandler , IDraggableSlot , IDisplaySlot
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;
    
    private DisplayController displayController;
    public int displayIndex {get; private set; }
    public GameItem currentItem {get; private set; }
    public SlotSourceType SourceType => SlotSourceType.Display;
    
    public void Bind(DisplayController controller, int index)
    {
        displayController = controller;
        displayIndex = index;
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
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if (displayController.GetItemAt(displayIndex) == null)
        {
            return;
        }

        
        DragItemUI.Instance.BeginDrag(displayController.GetItemAt(displayIndex));
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        
        if (displayController.GetItemAt(displayIndex) != null)
            DragItemUI.Instance.UpdatePosition(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragItemUI.Instance.EndDrag();
        RefreshSlot();
    }
    
    
    
    public void OnDrop(PointerEventData eventData)
    { 
        if (!DragItemUI.Instance.CanStartDrag())
            return;
        
        IDraggableSlot draggedSlot = eventData.pointerDrag?.GetComponent<IDraggableSlot>();
        
        if (draggedSlot == null) return;

        if (draggedSlot is IDisplaySlot fromDisplaySlot)
        {
            displayController.Swap(fromDisplaySlot.displayIndex,displayIndex); 
        }
        else
        {
            displayController.PlaceFromInventory(draggedSlot.currentItem.itemData, displayIndex);
        }

        draggedSlot.RefreshSlot();
        RefreshSlot();
    }
    
    public void RefreshSlot()
    {
        var item = displayController.GetItemAt(displayIndex);
        if (item != null)
            SetSlot(item, 1);
        else
            ClearSlot();
    }
    
    
}