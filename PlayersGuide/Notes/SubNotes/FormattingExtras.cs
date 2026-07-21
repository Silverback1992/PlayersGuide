namespace PlayersGuide.Notes.SubNotes;

public static class FormattingExtras
{
    public static void Show()
    {
        Console.WriteLine("Formatting Extras:");

        // Any 0 in the format indicates that you want a number to appear there even if the number isn't strictly necessary.
        Console.WriteLine($"{42:000.000}");

        // In contrast a # will leave a place for a digit but will not display anything if the number doesn't have a digit in that place.
        Console.WriteLine($"{42:###.###}");
        Console.WriteLine($"{42.1294:#.##}");

        // You can also use the % symbol to make a number be represented as a percent instead of a fraction.
        Console.WriteLine($"{4f / 9f:0.0%}");
    }
}
