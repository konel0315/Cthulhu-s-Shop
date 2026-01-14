public interface IDraggableSlot
{
    SlotSourceType SourceType { get; }
    InventoryItem currentItem { get;}
    public abstract void RefreshSlot();
}