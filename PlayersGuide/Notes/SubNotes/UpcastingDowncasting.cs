using PlayersGuide.Notes.SubNotes.UpcastingDowncastingHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class UpcastingDowncasting
{
    public static void Show()
    {
        Console.WriteLine("Upcasting and Downcasting:");

        // Upcasting (automatic, implicit)
        // what it is: moving up the inheritance chain (from Player to Entity)
        // why it's automatic: it is 100% safe. A Player is an Entity.
        // It contains all the exact same fields and properties as Entity has plus some extra.
        // The compiler knows it can never fail so it does it for you silently.

        // The object on the heap is a Player object.
        // The compiler with the somEntity variable looks at the object through the lens of an Entity
        // That is why you can't access the Name property

        var player2 = new Player(10, "AnotherName");
        player2.Id = 10;
        Entity someEntity = player2; // upcasting from Player to Entity
        someEntity.Id = 5; // we can still access the Entity's Id property because Player inherits from Entity

        Console.WriteLine(player2.Id);

        // Downcasting (manual/explicit)
        // what it is: moving down the inheritance chain (from Entity to Player)
        // why it's manual: it is dangerous. The compiler looks at the Entity variable and says 
        // "I know its an Entity but is it a Player? Or is it an Enemy? Or a Chest? I can't gurantee this is safe!
        // Therefore it forces you to explicitly tell it "trust me I know what I'm doing"

        Entity entity = new Player(10, "DowncastName");

        // 3 ways to check entity type at runtime

        // 1. GetType() method: returns the exact runtime type of the object. If you compare it to typeof(Player) you can check if it's a Player.
        if (entity.GetType() == typeof(Player))
        {
            Player downcastPlayer1 = (Player)entity;
        }

        // 2. as operator: attempts to cast the object to the specified type. If the cast is successful, it returns the object as that type. If it fails, it returns null instead of throwing an exception.
        var downcastPlayer2 = ((entity as Player));

        if (downcastPlayer2 != null)
        {
            // We are guranteed that downcastPlayer2 is a Player here because if the cast had failed it would have been assigned null
        }

        // 3. is operator: checks if the object is of a certain type. It returns true if the object is of that type or a derived type, and false otherwise.
        if (entity is Player downcastPlayer3)
        {
            // We are guranteed that downcastPlayer3 is a Player here because the is operator checks the type before assigning it to the variable
        }
    }
}
