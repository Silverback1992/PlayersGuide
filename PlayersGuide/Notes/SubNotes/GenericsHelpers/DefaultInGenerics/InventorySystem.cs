namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.DefaultInGenerics;

public class InventorySystem
{
    public T GetFirstItem<T>(List<T> items)
    {
        if (items.Count == 0)
        {
            return default(T); // Returns the default value for the type T
            // in this case both default and default(T) are equivalent and will return null for reference types and zero for value types
        }

        return items[0];
    }
}
