using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform slotParent;
    [SerializeField] private List<InventorySlotUI> slots;
    
    private InventoryController inventoryController;
    private DisplayController displayController;
    public void Bind(InventoryController inventoryController,DisplayController displayController)
    {
        this.inventoryController = inventoryController;
        this.displayController = displayController;
        RefreshUI();
        for (int i=0; i<slots.Count; i++)
        {
            slots[i].Bind(inventoryController,displayController);
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
                slots[i].SetSlot(items[i]);
            else
                slots[i].ClearSlot();
        }
    }
}