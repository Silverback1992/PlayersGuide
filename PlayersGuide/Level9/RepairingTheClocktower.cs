namespace PlayersGuide.Level9;

public class RepairingTheClocktower
{
    public static void Solution()
    {
        Console.WriteLine("Number: ");
        int number = int.Parse(Console.ReadLine()!);

        if (number % 2 == 0)
        {
            Console.WriteLine("Tick");
        }
        else
        {
            Console.WriteLine("Tock");
        }
    }
}
