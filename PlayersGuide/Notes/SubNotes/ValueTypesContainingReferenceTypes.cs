using PlayersGuide.Notes.SubNotes.ValueTypesContainingReferenceTypesHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class ValueTypesContainingReferenceTypes
{
    public static void Show()
    {
        Console.WriteLine("Value Types Containing Reference Types:");

        var a = (Troll: new Enemy { Health = 100 }, Id: 1);
        var b = a;
        b.Troll.Health = 50;
        b.Id = 99;

        Console.WriteLine($"a Tuple check: Troll hp: {a.Troll.Health} Id: {a.Id}");

        GameObject g = new GameObject();
        MyMethods.Foo(g);
    }
}
