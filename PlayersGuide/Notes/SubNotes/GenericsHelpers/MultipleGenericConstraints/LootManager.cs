namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.MultipleGenericConstraints;

public class LootManager
{
    // Look at how we stack the constraints! 
    // You just write 'where' again for the next generic type.
    public void GrantLoot<TPlayer, TReward>(TPlayer player)
        where TPlayer : class, IPlayer   // Rule 1: Must be a class AND implement IPlayer
        where TReward : IReward, new()   // Rule 2: Must implement IReward AND have a parameterless constructor
    {
        // Because of the 'new()' constraint on TReward, we can do this:
        TReward generatedLoot = new TReward();

        Console.WriteLine($"Generating {generatedLoot.ItemName}...");

        // Because of the 'IPlayer' constraint on TPlayer, we can do this:
        player.AddToInventory(generatedLoot.ItemName);

        Console.WriteLine($"Successfully granted to {player.Name}!");
    }
}
