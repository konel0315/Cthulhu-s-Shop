[System.Serializable]
public class GameItem
{
    public ItemSO itemData;
    public int Quantity;

    public GameItem(ItemSO item, int amount)
    {
        this.itemData = item;
        this.Quantity = amount;
    }
}