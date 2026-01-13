using System.Collections.Generic;

public class InventoryController
{
    List<InventoryItem> inventory = new List<InventoryItem>();
    public int maxInventorySlot { get; private set; } = 8;

    public void AddItem(ItemSO item, int amount)
    {
        var existing = inventory.Find(i => i.itemData == item);
        if(existing != null) existing.Quantity+=amount;
        inventory.Add(new InventoryItem(item, amount));
    }

    public bool RemoveItem(ItemSO item, int amount)
    {
        var existing = inventory.Find(i => i.itemData == item);
        if (existing != null && existing.Quantity >= amount)
        {
            existing.Quantity-=amount;
            if (existing.Quantity <= 0)
            {
                inventory.Remove(existing);
            }
            return true;
        }
        return false;
    }
    

}