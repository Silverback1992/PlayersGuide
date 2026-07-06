namespace PlayersGuide.Notes.Helpers.Generics.MultipleGenericConstraints;

public interface IPlayer
{
    string Name { get; }
    void AddToInventory(string itemName);
}
