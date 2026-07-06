namespace PlayersGuide.Notes.Helpers.Generics;

public class CustomGenericList<T>
{
    private T[] _items = [];

    public T GetItemAt(int index) => _items[index];
    public void SetItemAt(int index, T value) => _items[index] = value;

    public void Add(T value)
    {
        Array.Resize(ref _items, _items.Length + 1);
        _items[^1] = value;
    }
}
