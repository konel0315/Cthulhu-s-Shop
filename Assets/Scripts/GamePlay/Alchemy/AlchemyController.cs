using System.Collections.Generic;
using UnityEngine;

public class AlchemyController
{
    private const int MaxSlot = 5;
    private List<GameItem> items = new();
    public GameItem _craftedItem { get; private set; }

    public IReadOnlyList<GameItem> Items => items;

    private InventoryController inventory;
        
    public AlchemyController(InventoryController inventory)
    {
        this.inventory = inventory;
    }


    public bool CanAddItem()
    {
        return items.Count < MaxSlot;
    }

    public bool IsCrafted()
    {
        return _craftedItem != null;
    }

    
    public void AddItem(ItemSO itemData)
    {
        items.Add(new GameItem(itemData, 1));
        OnAlchemyChanged?.Invoke();
    }
    
	public void ReturnItem()
    {
        foreach (var item in items)
        {
            inventory.AddItem(item.itemData, item.Quantity);
        }
        items.Clear();
        OnAlchemyChanged?.Invoke();
    }
    public void AlchemyAllItems()
    {
        int ALlValue = 0;
        
        foreach (var item in items)
        {
            ALlValue+=item.itemData.baseValue;
        }
        items.Clear();
        ItemSO gold = Resources.Load<ItemSO>("Data/Item/Gold");
        _craftedItem= new GameItem(gold, (int)(ALlValue*(0.007)));
        OnAlchemyChanged?.Invoke();
    }

    public event System.Action OnAlchemyChanged;
}