namespace PlayersGuide.Notes.SubNotes;

public static class BinaryAndHexadecimalLiterals
{
    public static void Show()
    {
        Console.WriteLine("Binary and Hexadecimal Literals:");

        // Binary literals start with 0b
        int thirteen = 0b00001101; // 13 in binary
        Console.WriteLine($"Binary literal: {thirteen}");

        // Hexadecimal literals start with 0x
        int theColorMagenta = 0xFF00FF; // RGB hex code for magenta
        Console.WriteLine($"Hexadecimal literal: {theColorMagenta}");
    }
}
