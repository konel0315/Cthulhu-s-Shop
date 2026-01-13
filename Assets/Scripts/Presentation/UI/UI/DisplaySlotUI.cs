using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

class DisplaySlotUI : MonoBehaviour, IDropHandler
{
    [SerializeField] private Image icon;
    
    private DisplayController displayController;
    private int displayIndex;
    public void Bind(DisplayController controller, int index)
    {
        displayController = controller;
        displayIndex = index;
    }
    
    public void SetSlot(ItemSO item, int quantity)
    {
        icon.sprite = item.icon;
        gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        icon.sprite = Resources.Load<Sprite>("UI/투명");
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        SlotUI draggedSlot = eventData.pointerDrag?.GetComponent<SlotUI>();
        if (draggedSlot == null) return;

        InventoryItem draggedItem = draggedSlot.currentItem;
        if (draggedItem == null) return;

        // 디스플레이에 아이템 놓기 시도
        bool success = displayController.PlaceFromInventory(draggedItem.itemData, displayIndex);

        // DragItemUI는 단순 시각용
        DragItemUI.Instance.EndDrag();

        if (!success)
        {
            // 실패 시 드래그 슬롯과 이 슬롯 UI 원상복구
            draggedSlot.RefreshSlot();
            RefreshSlot();
        }
        else
        {
            RefreshSlot();
        }
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