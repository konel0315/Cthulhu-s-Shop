[System.Serializable]
public class InventoryItem
{
    public ItemSO itemData;
    public int Quantity;

    public InventoryItem(ItemSO item, int amount)
    {
        this.itemData = item;
        this.Quantity = amount;
    }
}