namespace PlayersGuide.Notes.Helpers.Generics.MultipleGenericConstraints;

public class Paladin : IPlayer
{
    public string Name => "Arthur";
    public void AddToInventory(string itemName) => Console.WriteLine($"[Inventory] Added {itemName}");
}
