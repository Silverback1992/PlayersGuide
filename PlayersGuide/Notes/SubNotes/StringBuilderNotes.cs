using System.Text;

namespace PlayersGuide.Notes.SubNotes;

public static class StringBuilderNotes
{
    public static void Show()
    {
        Console.WriteLine("StringBuilder notes:");

        // Not optimized
        string text = "";

        while (true)
        {
            string? input = Console.ReadLine();

            if (input == null || input == "")
            {
                break;
            }

            text += input;
            text += ' ';
        }

        Console.WriteLine(text);

        // Optimized version
        var sb = new StringBuilder();

        while (true)
        {
            string? input = Console.ReadLine();

            if (input == null || input == "")
            {
                break;
            }

            sb.Append(input);
            sb.Append(' ');
        }

        Console.WriteLine(sb);
    }
}
