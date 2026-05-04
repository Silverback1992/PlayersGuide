namespace PlayersGuide.Level7;

public static class TheFourSistersAndTheDuckbear
{
    public static void Solution()
    {
        Console.WriteLine("Number of eggs:");
        int numberOfEggs = int.Parse(Console.ReadLine()!);

        int eggsPerSister = numberOfEggs / 4;
        Console.WriteLine($"Sisters each get: {eggsPerSister} eggs.");

        int remainingEggs = numberOfEggs % 4;
        Console.WriteLine($"Duckbear gets: {remainingEggs} eggs.");
    }
}
