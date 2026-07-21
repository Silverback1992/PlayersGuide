namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.MultipleGenericConstraints;

public interface IPlayer
{
    string Name { get; }
    void AddToInventory(string itemName);
}
