namespace PlayersGuide.Notes.Helpers.Generics.NakedTypeConstraints;

public class InventorySystem
{
    public void AddToList<TBase, TItem>(List<TBase> list, TItem item)
        where TItem : TBase
    {
        list.Add(item);
    }
}
