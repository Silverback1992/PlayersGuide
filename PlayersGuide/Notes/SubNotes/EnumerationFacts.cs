using PlayersGuide.Notes.SubNotes.EnumerationFactsHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class EnumerationFacts
{
    public static void Show()
    {
        Console.WriteLine("Enumeration Facts:");

        // First item you list will be the enumeration's default value.
        var mySeason = new Season();
        Console.WriteLine($"Enumeration default value check: {mySeason}");

        // Default underlying type is int, but you can specify a different integral type if you want.
        // Check OtherSeason enum

        // If you want you can assign custom numbers
        // Check CustomSeason enum

        // Any enumeration member without an assigned number is automatically given the one after the member before it.
        // Check AutoSeason enum
        var myAutoSeason = AutoSeason.Spring;
        Console.WriteLine($"Autoincrement enum value check: {myAutoSeason:D}");
    }
}
