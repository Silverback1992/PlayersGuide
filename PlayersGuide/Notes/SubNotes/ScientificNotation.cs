namespace PlayersGuide.Notes.SubNotes;

public static class ScientificNotation
{
    public static void Show()
    {
        Console.WriteLine("Scientific Notation:");

        // Floating point literals can embed e or E in a number
        double avogadrosNumber = 6.022e23; // 6.022 x 10^23
        Console.WriteLine($"Avogadro's number: {avogadrosNumber}");
    }
}
