using System.Collections.Generic;
using UnityEngine;

public class AlchemyInventoryUI : MonoBehaviour
{
    [SerializeField] private List<AlchemyInventorySlotUI> slots;

    private InventoryController inventoryController;
    private AlchemyController alchemyController;

    public void Bind(InventoryController inventoryController, AlchemyController alchemyController)
    {
        this.inventoryController = inventoryController;
        this.alchemyController = alchemyController;
        inventoryController.OnInventoryChanged += RefreshUI;
        RefreshUI();

        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].Bind(inventoryController, alchemyController);
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