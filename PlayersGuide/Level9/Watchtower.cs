namespace PlayersGuide.Level9;

public static class Watchtower
{
    public static void Solution()
    {
        Console.Write("x value: ");
        int x = int.Parse(Console.ReadLine()!);

        Console.Write("y value: ");
        int y = int.Parse(Console.ReadLine()!);

        string baseMessage = "The enemy is";

        if (x < 0 && y > 0)
        {
            Console.WriteLine($"{baseMessage} to the northwest!");
        }
        else if (x > 0 && y > 0)
        {
            Console.WriteLine($"{baseMessage} to the northeast!");
        }
        else if (x < 0 && y < 0)
        {
            Console.WriteLine($"{baseMessage} to the southwest!");
        }
        else if (x > 0 && y < 0)
        {
            Console.WriteLine($"{baseMessage} to the southeast!");
        }
        else if (y == 0 && x < 0)
        {
            Console.WriteLine($"{baseMessage} to the west!");
        }
        else if (x == 0 && y == 0)
        {
            Console.WriteLine($"{baseMessage} here!");
        }
        else if (x == 0 && y > 0)
        {
            Console.WriteLine($"{baseMessage} to the north!");
        }
        else if (x == 0 && y < 0)
        {
            Console.WriteLine($"{baseMessage} to the south!");
        }
        else if (y == 0 && x > 0)
        {
            Console.WriteLine($"{baseMessage} to the east!");
        }
    }
}
