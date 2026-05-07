using PlayersGuide.Level13;

namespace PlayersGuide.Level11;

public static class ThePrototype
{
    public static void Solution()
    {
        int number = TakingANumber.AskForNumberInRange("User 1, enter a number between 0 and 100: ", 0, 100);

        Console.Clear();

        Console.WriteLine("User 2, guess the number.");

        int guess;

        do
        {
            guess = TakingANumber.AskForANumber("What is your next guess? ");

            if (guess > number)
            {
                Console.WriteLine($"{guess} is too high.");
            }

            if (guess < number)
            {
                Console.WriteLine($"{guess} is too low.");
            }

            if (guess == number)
            {
                Console.WriteLine("You guessed the number!");
            }

        } while (guess != number);
    }
}
