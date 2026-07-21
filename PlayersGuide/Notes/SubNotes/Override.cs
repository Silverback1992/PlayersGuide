namespace PlayersGuide.Notes.SubNotes;

public static class Override
{
    public static void Show()
    {
        // When a normal (non-virtual) method is called, the compiler can determine which method to call at compile time.
        // When a method is virtual, it cannot. Instead it records some metadata in the compiled code to know what to look up as it is running.

        // An overrding method must match the name and parameters (both count and type) as the overriden method.
        // However you can use a more specific type for the return value if you want.
        // Check the Base and Derived classes in the Helpers folder for an example of this in action.
    }
}
