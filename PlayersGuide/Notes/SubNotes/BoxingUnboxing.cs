using PlayersGuide.Notes.SubNotes.BoxingUnboxingHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class BoxingUnboxing
{
    public static void Show()
    {
        object thing = 3; // Boxing: the int value 3 is being boxed into an object
        int unboxedThing = (int)thing; // unboxing

        // same can happen with structs and interfaces
        ISomeInterface someInterface = new SomeStruct(); // Boxing: the struct is being boxed into an interface
        SomeStruct unboxedStruct = (SomeStruct)someInterface; // unboxing
    }
}
