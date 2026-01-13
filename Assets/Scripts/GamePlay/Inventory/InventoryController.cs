using System;
using System.Collections.Generic;

public class InventoryController
{
    List<InventoryItem> inventory = new List<InventoryItem>();
    
    public event Action OnInventoryChanged;
    public int maxInventorySlot { get; private set; } = 8;
    public DisplayController displayController;
    
    public InventoryController()
    {

        displayController = new DisplayController(this);
    }


    public bool AddItem(ItemSO item, int amount)
    {
        if (item.canStack)
        {
            var existing = inventory.Find(i => i.itemData == item);
            if (existing != null)
            {
                existing.Quantity += amount;
                OnInventoryChanged?.Invoke();
                return true;
            }
        }
        if (inventory.Count < maxInventorySlot)
        {
            inventory.Add(new InventoryItem(item, amount));
            OnInventoryChanged?.Invoke();
            return true;
        }
        return false;
    }
    
    public bool RemoveItem(ItemSO item, int amount)
    {
        var existing = inventory.Find(i => i.itemData == item);
        if (existing == null)
            return false;

        if (item.canStack)
        {
            if (existing.Quantity < amount)
                return false;

            existing.Quantity -= amount;
            if (existing.Quantity <= 0)
                inventory.Remove(existing);
        }
        else
        {
            inventory.Remove(existing);
        }

        OnInventoryChanged?.Invoke();
        return true;
    }
    
    public List<InventoryItem> GetAllItems()
    {
        return new List<InventoryItem>(inventory);
    }


}