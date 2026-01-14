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

            if (inventory.Count + 1 > maxInventorySlot)
                return false;

            inventory.Add(new InventoryItem(item, amount));
            OnInventoryChanged?.Invoke();
            return true;
        }
        else
        {
            if (inventory.Count + amount > maxInventorySlot)
                return false;

            for (int i = 0; i < amount; i++)
            {
                inventory.Add(new InventoryItem(item, 1));
            }

            OnInventoryChanged?.Invoke();
            return true;
        }
    }


    public bool RemoveItem(ItemSO item, int amount)
    {
        if (item.canStack)
        {
            var existing = inventory.Find(i => i.itemData == item);
            if (existing == null || existing.Quantity < amount)
                return false;

            existing.Quantity -= amount;
            if (existing.Quantity <= 0)
                inventory.Remove(existing);
        }
        else
        {
            int removed = 0;
            for (int i = inventory.Count - 1; i >= 0 && removed < amount; i--)
            {
                if (inventory[i].itemData == item)
                {
                    inventory.RemoveAt(i);
                    removed++;
                }
            }

            if (removed < amount)
                return false;
        }

        OnInventoryChanged?.Invoke();
        return true;
    }


    public List<InventoryItem> GetAllItems()
    {
        return new List<InventoryItem>(inventory);
    }

    public InventoryItem GetItem(int slot) => inventory[slot];
}