public interface IItemContainer
{
    int ItemCount(Item item);
    bool ContainsItem(Item item);
    bool RemoveItem(Item item);
    bool AddItem(Item item);
    bool IsFull();
}