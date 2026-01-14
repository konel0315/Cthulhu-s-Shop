using System;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController
{
    private const int DISPLAY_SLOT_COUNT = 3;

    private ItemSO[] displaySlots = new ItemSO[DISPLAY_SLOT_COUNT];
    private InventoryController inventoryController;

    private bool canEditDisplay = true;
    public event Action OnDisplayChanged;
    
    public DisplayController(InventoryController inventoryController)
    {
        this.inventoryController = inventoryController;
    }

    public void SetEditable(bool editable)
    {
        canEditDisplay = editable;
    }
    
    private bool IsEditable()
    {
        return canEditDisplay;
    }
    
    /* =========================
     * 조회
     * ========================= */

    public ItemSO GetItemAt(int index)
    {
        if (!IsValidIndex(index)) return null;
        return displaySlots[index];
    }

    public List<ItemSO> GetAllDisplayedItems()
    {
        List<ItemSO> result = new List<ItemSO>();
        foreach (var item in displaySlots)
        {
            if (item != null)
                result.Add(item);
        }
        return result;
    }

    /* =========================
     * 배치 / 이동
     * ========================= */

    // Inventory → Display
    public bool PlaceFromInventory(ItemSO item, int displayIndex)
    {
        Debug.Log("PlaceFromInventory");
        if (!IsEditable()) {Debug.Log("PlaceFromInventory2");return false;}
        if (!IsValidIndex(displayIndex)) {Debug.Log("PlaceFromInventory23");return false;}
        if (!item.canDisplay) {Debug.Log("PlaceFromInventory24");return false;}
        
        // 인벤토리에서 1개 제거 가능한지 확인
        if (!inventoryController.RemoveItem(item, 1))
            return false;

        ItemSO existing = displaySlots[displayIndex];

        // 기존 아이템이 있으면 인벤토리로 반환
        if (existing != null)
        {
            inventoryController.AddItem(existing, 1);
        }

        displaySlots[displayIndex] = item;
        OnDisplayChanged?.Invoke();
        return true;
    }

    // Display → Inventory
    public bool ReturnToInventory(int displayIndex)
    {
        if (!IsEditable()) return false;
        if (!IsValidIndex(displayIndex)) return false;

        ItemSO item = displaySlots[displayIndex];
        if (item == null) return false;

        // 인벤토리에 공간 없으면 실패
        if (!inventoryController.AddItem(item, 1))
            return false;

        displaySlots[displayIndex] = null;
        OnDisplayChanged?.Invoke();
        return true;
    }

    // Display ↔ Display
    public bool Swap(int indexA, int indexB)
    {
        if (!IsValidIndex(indexA) || !IsValidIndex(indexB)) return false;
        if (indexA == indexB) return false;

        ItemSO temp = displaySlots[indexA];
        displaySlots[indexA] = displaySlots[indexB];
        displaySlots[indexB] = temp;

        OnDisplayChanged?.Invoke();
        return true;
    }

    /* =========================
     * 판매 / 소비
     * ========================= */

    // 손님이 특정 슬롯의 아이템을 구매/소비
    public ItemSO ConsumeDisplayedItem(int displayIndex)
    {
        if (!IsValidIndex(displayIndex)) return null;

        ItemSO item = displaySlots[displayIndex];
        if (item == null) return null;

        displaySlots[displayIndex] = null;
        OnDisplayChanged?.Invoke();
        return item;
    }

    /* =========================
     * 유틸
     * ========================= */

    private bool IsValidIndex(int index)
    {
        return index >= 0 && index < DISPLAY_SLOT_COUNT;
    }
    
}
