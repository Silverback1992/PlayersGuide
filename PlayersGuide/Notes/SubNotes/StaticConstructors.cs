using PlayersGuide.Notes.SubNotes.StaticConstructorsHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class StaticConstructors
{
    public static void Show()
    {
        Console.WriteLine("Static constructors:");

        // If a class has static fields or properties you may need to run some logic to initialize them.
        // To address this, you could define a static constructor.

        // A static constructor cannot have parameters, nor can you call it directly.
        // Instead it runs automatically the first time you use the class.
        // Because of this you cannot place an accessibility modifier like public or private on it.

        // Check Dog class in Helpers folder
        Console.WriteLine($"Dog static constructor check: {Dog.Name}");

        // For a more realistic example check out AppEnvironment class in Helpers folder
    }
}
