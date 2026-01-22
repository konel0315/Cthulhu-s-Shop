using System;
using UnityEditorInternal.Profiling.Memory.Experimental;

public class HoldingAreaController
{
    private PendingItem givingItem;
    private PendingItem takingItem;

    private readonly InventoryController inventoryController;
    private readonly DisplayController displayController;
    
    public event Action OnHoldingAreaChanged;
    public event Action OnTakingEmptied;

    public HoldingAreaController(
        InventoryController inventoryController,
        DisplayController displayController)
    {
        this.inventoryController = inventoryController;
        this.displayController = displayController;
    }

    public bool HasGiving => givingItem != null;
    public bool HasTaking => takingItem != null;

    public bool IsItem(string itemName, int amount)
    {
        if (!HasGiving) return false;
        return givingItem.item.Name == itemName &&
               givingItem.quantity >= amount;
    }
    
    public PendingItem GetGiving() => givingItem;
    public PendingItem GetTaking() => takingItem;

    public void AddFromInventory(ItemSO item, int quantity)
    {
        if (HasGiving) return;
        if (item == null || quantity <= 0) return;
        if (item.Name != "금") return;

        if (!inventoryController.RemoveItem(item, quantity)) return;

        givingItem = new PendingItem
        {
            item = item,
            quantity = quantity,
            source = ItemSource.Inventory
        };
        OnHoldingAreaChanged?.Invoke();
    }

    public void AddFromDisplay(ItemSO item, int index)
    {
        if (HasGiving) return;
        if (item == null) return;

        if (!displayController.RemoveAt(index)) return;

        givingItem = new PendingItem
        {
            item = item,
            quantity = 1,
            source = ItemSource.Display,
            sourceIndex = index
        };
        OnHoldingAreaChanged?.Invoke();
    }
    
    public void CreateTaking(ItemSO item, int quantity)
    {
        if (HasTaking) return;

        takingItem = new PendingItem
        {
            item = item,
            quantity = quantity
        };

        OnHoldingAreaChanged?.Invoke();
    }

    public void ReturnTakingItemToInventory()
    {
        if (!HasTaking) return;
        
        inventoryController.AddItem(takingItem.item, takingItem.quantity);
        takingItem = null;
        OnHoldingAreaChanged?.Invoke();
        OnTakingEmptied?.Invoke();
    }
    
    public void Accept()
    {
        givingItem = null;
        OnHoldingAreaChanged?.Invoke();
    }

    public void Reject()
    {
        if (givingItem == null) return;

        if (givingItem.source == ItemSource.Inventory)
        {
            inventoryController.AddItem(givingItem.item, givingItem.quantity);
        }
        else
        {
            displayController.PlaceFromHoldinArea(
                givingItem.item,
                givingItem.sourceIndex
            );
        }

        givingItem = null;
        OnHoldingAreaChanged?.Invoke();
    }
}