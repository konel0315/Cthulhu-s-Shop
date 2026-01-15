public interface IDraggableSlot
{
    SlotSourceType SourceType { get; }
    GameItem currentItem { get;}
    public abstract void RefreshSlot();
}