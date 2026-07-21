using PlayersGuide.Notes.SubNotes.RecordsHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class Records
{
    public static void Show()
    {
        Console.WriteLine("Records:");

        var pointA = new Point(1, 2);
        //pointA.X = 3; // Compiler error: Cannot modify because Point is a record and is immutable

        // string representation of a record is automatically generated for us
        Console.WriteLine($"Point A: {pointA}");

        // Value semantics: two records with the same data are considered equal
        var pointB = new Point(1, 2);
        Console.WriteLine($"Point A == Point B: {pointA == pointB}");

        // Deconstruction: we can deconstruct a record into its individual values
        var (extractedX, extractedY) = pointA;
        Console.WriteLine($"Extracted X: {extractedX}, Extracted Y: {extractedY}");

        // with statement
        var pointC = pointA with { X = 3 }; // creates a new record with the same data as pointA but with X changed to 3

        // Note: with can be used with records, structs and anonymous types
        var coolStruct = new CoolStruct();
        var coolStruct2 = coolStruct with { CoolPropertyA = 3 }; // creates a new struct with the same data as coolStruct but with CoolPropertyA changed to 3

        var anonymousUser = new { Name = "John", Age = 30 };
        var copiedUser = anonymousUser with { Age = 31 }; // creates a new anonymous type with the same data as anonymousUser but with Age changed to 31
    }
}
