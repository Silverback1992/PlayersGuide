namespace PlayersGuide.Notes.SubNotes;

public static class BuiltInTypeAliases
{
    public static void Show()
    {
        // The built in types that are value types are not just value types but structs themselves.
        // While rarely used we could refer to them with their full names instead of the aliases. For example we could use System.Int32 instead of int, System.Boolean instead of bool, System.String instead of string, etc.
        Int32 myInt = new();
        int x = 5; //  int is actually an alias for System.Int32
        x = 6;
    }
}
