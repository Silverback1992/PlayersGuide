using PlayersGuide.Notes.SubNotes.SystemTypeHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class SystemType
{
    public static void Show()
    {
        Console.WriteLine("System.Type:");
        Console.WriteLine();

        Type t = typeof(string);
        Console.WriteLine("String details:");
        Console.WriteLine(t.Name);
        Console.WriteLine(t.FullName);
        Console.WriteLine(t.IsValueType);
        Console.WriteLine(t.IsClass);
        Console.WriteLine(t.BaseType.Name);

        Console.WriteLine();

        Type t2 = typeof(int);
        Console.WriteLine("Int details:");
        Console.WriteLine(t2.Name);
        Console.WriteLine(t2.IsValueType);

        // Two ways to get the Type of an object
        Type a = typeof(Player); // from a type NAME
        Player p = new Player();
        Type b = p.GetType(); // from an object instance

        Console.WriteLine("Player details through polymorphism:");
        // GetType also gives you the actual type sitting in memory
        Entity e = new Player();
        Console.WriteLine(e.GetType().Name);

        // every type has exactly one Type object for the whole process
        Console.WriteLine("Checking if myType1 and myType2 are the same instance:");
        Type myType1 = typeof(string);
        Type myType2 = "hello".GetType();
        Console.WriteLine(object.ReferenceEquals(myType1, myType2));
    }
}
