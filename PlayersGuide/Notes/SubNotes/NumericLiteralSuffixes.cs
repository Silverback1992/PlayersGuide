using PlayersGuide.Notes.SubNotes.NumericLiteralSuffixesHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class NumericLiteralSuffixes
{
    public static void Show()
    {
        Console.WriteLine("Numeric Literal Suffixes:");

        // When you write 
        ulong aVeryBigNumber = 10000000000;
        // you are taking a long literal and letting the compiler implicitly convert it to ulong.
        // The compiler allows this because it knows 10 billion fits within the range of ulong.

        // Adding the UL simply skips the impilict conversion step.
        // You are telling the compiler "Don't guess. Treat this raw number as a ulong literal right away."
        ulong bVeryBigNumber = 10_000_000_000UL;

        // This matters because:
        // 1. Variables declared with var.
        var bigNumber1 = 10000000000; // bigNumber1 is of type long
        var bigNumber2 = 10_000_000_000UL; // bigNumber2 is of type ulong

        // 2. Method overloads that take different numeric types.
        MyMath.DoMath(100); // Calls DoMath(int)
        MyMath.DoMath(100L); // Calls DoMath(long)

        // 3. Math overflow trap
        unchecked
        {
            long result = 2000000000 + 2000000000; // This will cause an overflow if treated as int
            Console.WriteLine($"Unchecked overflow example: {result}");
        }

        unchecked
        {
            long result = 2000000000L + 2000000000; // This will cause an overflow if treated as int
            Console.WriteLine($"Overflow fixed with suffix: {result}");
        }
    }
}
