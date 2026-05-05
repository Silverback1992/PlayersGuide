namespace PlayersGuide.Level11;

public static class TheMagicCannon
{
    public static void Solution()
    {
        for (int i = 1; i < 100; i++)
        {
            FireTheCannon(i);
        }
    }

    private static void FireTheCannon(int n)
    {
        if (n % 3 == 0 && n % 5 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{n}: Electric and Fire");
            return;
        }

        if (n % 3 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{n}: Fire");
            return;
        }

        if (n % 5 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{n}: Electric");
            return;
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"{n}: Normal");
    }
}
