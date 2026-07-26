namespace PlayersGuide.Notes.SubNotes;

public static class CharNotes
{
    public static void Show()
    {
        Console.WriteLine("Char notes:");

        char c = 'A';
        int code = c;
        char back = (char)66;
        Console.WriteLine((int)'a');

        Console.WriteLine("Char arithmetics");
        char next = (char)('A' + 1);
        for (char letter = 'a'; letter <= 'z'; letter++)
        {
            Console.Write(letter);
        }

        Console.WriteLine();
    }
}
