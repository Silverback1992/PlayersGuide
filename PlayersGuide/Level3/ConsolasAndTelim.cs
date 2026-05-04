namespace PlayersGuide.Level3;

public static class ConsolasAndTelim
{
    public static void Solution()
    {
        Console.WriteLine("Bread is ready.");
        Console.WriteLine("Who is the bread for?");
        string? name = Console.ReadLine();
        Console.WriteLine($"Noted: {name} got bread.");
    }
}
