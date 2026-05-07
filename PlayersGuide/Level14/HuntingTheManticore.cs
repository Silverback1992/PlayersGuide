using PlayersGuide.Level13;

namespace PlayersGuide.Level14;

public static class HuntingTheManticore
{
    public static void Solution()
    {
        int distance = TakingANumber.AskForNumberInRange("Player 1, how far away from the city do you want to station the Manticore? ", 0, 100);

        Console.Clear();

        Console.WriteLine("Player 2, it is your turn.");
        Console.WriteLine("-----------------------------------------------------------");

        int cityHealth = 15;
        int manticoreHealth = 10;
        int round = 1;

        do
        {
            Console.WriteLine($"STATUS: Round {round} City: {cityHealth}/15 HP Manticore: {manticoreHealth}/10 HP");

            int cannonDamage = CalculateCannonDamage(round);
            Console.WriteLine($"The cannon is expected to deal {cannonDamage} damage this round.");

            int cannonRange = TakingANumber.AskForANumber("Enter desired cannon range: ");

            if (IsAHit(distance, cannonRange))
            {
                manticoreHealth -= cannonDamage;
            }

            cityHealth--;
            round++;

            Console.WriteLine("-----------------------------------------------------------");

        } while (cityHealth > 0 && manticoreHealth > 0);

        if (manticoreHealth <= 0)
        {
            Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
            return;
        }

        Console.WriteLine("The city of Consolas has been destroyed! The Manticore has triumphed!");
    }

    private static bool IsAHit(int distance, int cannonRange)
    {
        if (distance < cannonRange)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("That round OVERSHOT the target.");
            Console.ResetColor();
            return false;
        }

        if (distance > cannonRange)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("That round FELL SHORT of the target.");
            Console.ResetColor();
            return false;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("That round was a DIRECT HIT!");
        Console.ResetColor();

        return true;
    }

    private static int CalculateCannonDamage(int round)
    {
        if (round % 3 == 0 && round % 5 == 0)
        {
            return 10;
        }

        if (round % 3 == 0)
        {
            return 3;
        }

        if (round % 5 == 0)
        {
            return 3;
        }

        return 1;
    }
}
