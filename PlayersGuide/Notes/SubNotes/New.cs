using PlayersGuide.Notes.SubNotes.NewHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class New
{
    public static void Show()
    {
        Console.WriteLine("new:");

        // If a derived class defines a member whose name matches something in a base class without overriding it a new member will be reated which hides (instead of overrides) the base class member.
        // This is nearly always an accident caused by forgetting the override keyword. The compiler assumes as much and gives you a warning for it.

        // In the rare cases where this was by design you can tell the compiler it was intentional by adding the new keyword to the member in the derived class.

        // When a new member is defined unlike polymorphism the behaviour depends on the type of the variable involved not the instance's type.
        Derived derived = new();
        Base myBase = derived;
        Console.WriteLine($"Derived and base check: {derived.Method} {myBase.Method}");
    }
}
