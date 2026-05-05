namespace PlayersGuide.Level8;

public static class TheDefenseOfConsolas
{
    public static void Solution()
    {
        Console.Title = "Defense of Consolas";

        Console.Write("Target Row? ");
        int row = int.Parse(Console.ReadLine()!);

        Console.Write("Target Column? ");
        int column = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Deploy to:");

        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine($"({row}, {column - 1})");
        Console.WriteLine($"({row - 1}, {column})");
        Console.WriteLine($"({row}, {column + 1})");
        Console.WriteLine($"({row + 1}, {column})");

        Console.Beep();
        Console.ReadKey(true);

        Console.ForegroundColor = ConsoleColor.White;
    }
}
