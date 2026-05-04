namespace PlayersGuide.Level7;

public static class TheDominionOfKings
{
    public static void Solution()
    {
        Console.WriteLine("Number of estates:");
        int estates = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Number of duchies:");
        int duchies = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Number of provinces:");
        int provinces = int.Parse(Console.ReadLine()!);

        int totalPoints = (estates * 1) + (duchies * 3) + (provinces * 6);
        Console.WriteLine($"Total points: {totalPoints}");
    }
}
