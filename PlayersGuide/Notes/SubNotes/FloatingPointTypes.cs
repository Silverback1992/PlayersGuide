namespace PlayersGuide.Notes.SubNotes;

public static class FloatingPointTypes
{
    public static void Show()
    {
        Console.WriteLine("Floating Point Types:");

        // Floating point types
        // Type     Bytes       Digits of Precision
        // float    4           7
        // double   8           15-16
        // decimal  16          28-29
        float myFloat = 1.55555555555555555f; // 7 digits of precision
        Console.WriteLine($"Float precision check: {myFloat}");
        double myDouble = 1.555555555555555555555555555555555555555555555555555; // 15-16 digits of precision
        Console.WriteLine($"Double precision check: {myDouble}");
        decimal myDecimal = 1.55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555m; // 28-29 digits of precision
        Console.WriteLine($"Decimal precision check: {myDecimal}");

        // The precision is a range because the maximum binary value in memory doesn't end in a perfect string of 9s.
        // The lower number in the range (e.g. 28 for decimal) is the number of digits that are guaranteed to be accurate,
        // while the upper number (e.g. 29 for decimal) is the maximum number of digits that can be stored but only if the number doesn't exceed the binary limits.
    }
}
