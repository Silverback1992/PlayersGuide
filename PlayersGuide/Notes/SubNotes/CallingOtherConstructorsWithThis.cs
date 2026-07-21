using PlayersGuide.Notes.SubNotes.CallingOtherConstructorsWithThisHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class CallingOtherConstructorsWithThis
{
    public static void Show()
    {
        Console.WriteLine("Calling other constructors with this:");

        // Check City class in Helpers folder

        var defaultCity = new City();
        Console.WriteLine($"Default city check: {defaultCity.Name} {defaultCity.ZipCode}");
    }
}
