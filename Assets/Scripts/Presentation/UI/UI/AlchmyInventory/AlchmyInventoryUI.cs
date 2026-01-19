using System.Collections.Generic;
using UnityEngine;

public class AlchemyInventoryUI : MonoBehaviour
{
    [SerializeField] private List<AlchemyInventorySlotUI> slots;

    private InventoryController inventoryController;

    public void Bind(InventoryController inventoryController)
    {
        this.inventoryController = inventoryController;
        inventoryController.OnInventoryChanged += RefreshUI;
        RefreshUI();

        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].Bind(inventoryController);
        }
    }

    private void RefreshUI()
    {
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