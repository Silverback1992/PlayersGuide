using PlayersGuide.Notes.SubNotes.InheritanceAndConstructorsHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class InheritanceAndConstructors
{
    public static void Show()
    {
        // When you create a derived class it is fundamentally built on top of the base class
        // Because of this the base class must be fully constructed in memory before the derived class can be constructed.

        // The invisible default
        // If your base class has no constructors defined, C# gives it an invisible parameterless constructor.
        // When your derived class is created, C# secretly calls base() behind the scenes.

        // The strict base (:base)
        // Once you define a custom constructor in a base class with parameters, C# deletes the invisible default constructor.
        // Now the base class requires data to be built.
        // Because the base must be built first, the derived class is forced to collect the necessary data and pass it up to the base constructor using the :base syntax.

        // Check Entity and Player classes in the Helpers folder for an example of this in action.

        var player = new Player(10, "SomeName");
    }
}
