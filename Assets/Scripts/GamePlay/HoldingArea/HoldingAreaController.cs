using System;
using UnityEditorInternal.Profiling.Memory.Experimental;

public class HoldingAreaController
{
    private PendingItem pending;

    private readonly InventoryController inventoryController;
    private readonly DisplayController displayController;
    
    public event Action OnHoldingAreaChanged;

    public HoldingAreaController(
        InventoryController inventoryController,
        DisplayController displayController)
    {
        this.inventoryController = inventoryController;
        this.displayController = displayController;
    }

    public bool HasItem => pending != null;

    public bool IsItem(String itemName, int amount)
    {
        if(pending.item.Name == itemName&&pending.quantity>=amount) return true;
        return false;
    }
    
    public PendingItem GetItem()=>pending;
    public void AddFromInventory(ItemSO item, int quantity)
    {
        if (HasItem) return;
        if (item == null || quantity <= 0) return;
        if (item.Name != "금") return;

        if (!inventoryController.RemoveItem(item, quantity)) return;

        pending = new PendingItem
        {
            item = item,
            quantity = quantity,
            source = ItemSource.Inventory
        };
        OnHoldingAreaChanged?.Invoke();
    }

    public void AddFromDisplay(ItemSO item, int index)
    {
        if (HasItem) return;
        if (item == null) return;

        if (!displayController.RemoveAt(index)) return;

        pending = new PendingItem
        {
            item = item,
            quantity = 1,
            source = ItemSource.Display,
            sourceIndex = index
        };
        OnHoldingAreaChanged?.Invoke();
    }

    public void Accept()
    {
        pending = null;
        OnHoldingAreaChanged?.Invoke();
    }

    public void Reject()
    {
        if (pending == null) return;

        if (pending.source == ItemSource.Inventory)
        {
            inventoryController.AddItem(pending.item, pending.quantity);
        }
        else
        {
            displayController.PlaceFromHoldinArea(
                pending.item,
                pending.sourceIndex
            );
        }

        pending = null;
        OnHoldingAreaChanged?.Invoke();
    }
}