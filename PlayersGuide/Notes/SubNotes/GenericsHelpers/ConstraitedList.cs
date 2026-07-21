namespace PlayersGuide.Notes.SubNotes.GenericsHelpers;

public class ConstraitedList<T> where T : GameObject
{
    private T[] _items = [];

    public T? GetItemByID(int id)
    {
        return _items.FirstOrDefault(item => item.ID == id);
    }

    public void Add(T value)
    {
        Array.Resize(ref _items, _items.Length + 1);
        _items[^1] = value;
    }
}
