using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform slotParent;
    [SerializeField] private List<SlotUI> slots;

    private InventoryController inventoryController;

    public void Bind(InventoryController inventoryControllercontroller)
    {
        inventoryController = inventoryControllercontroller;
        RefreshUI();
        for (int i=0; i<slots.Count; i++)
        {
            slots[i].Bind(inventoryController,i);
        }
        inventoryController.OnInventoryChanged += RefreshUI;
    }
    
    
    

    public void RefreshUI()
    {
        if (inventoryController == null) return;

        var items = inventoryController.GetAllItems();

        for (int i = 0; i < slots.Count; i++)
        {
            if (i < items.Count)
                slots[i].SetSlot(items[i].itemData, items[i].Quantity);
            else
                slots[i].ClearSlot();
        }
    }
}