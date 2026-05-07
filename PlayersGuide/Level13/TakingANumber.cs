namespace PlayersGuide.Level13;

public static class TakingANumber
{
    public static int AskForANumber(string text)
    {
        Console.Write(text);
        return int.Parse(Console.ReadLine()!);
    }

    public static int AskForNumberInRange(string text, int min, int max)
    {
        while (true)
        {
            int number = AskForANumber(text);

            if (number >= min && number <= max)
            {
                return number;
            }

            Console.WriteLine($"Please enter a number between {min} and {max}.");
        }
    }
}
