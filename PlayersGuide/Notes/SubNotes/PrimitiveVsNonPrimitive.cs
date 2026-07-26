using PlayersGuide.Notes.SubNotes.PrimitiveVsNonPrimitiveHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class PrimitiveVsNonPrimitive
{
    public static void Show()
    {
        Console.WriteLine("Primitive vs non primitive notes:");

        Console.WriteLine($"char check: {typeof(char).IsPrimitive}");
        Console.WriteLine($"DateTime check: {typeof(DateTime).IsPrimitive}");
        Console.WriteLine($"Custom struct check: {typeof(MyStruct).IsPrimitive}");
    }
}
