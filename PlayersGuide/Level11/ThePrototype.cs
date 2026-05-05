namespace PlayersGuide.Level11;

public static class ThePrototype
{
    public static void Solution()
    {
        int number;

        do
        {
            Console.Write("User 1, enter a number between 0 and 100: ");
            number = int.Parse(Console.ReadLine()!);
        } while (number < 0 || number > 100);

        Console.Clear();

        Console.WriteLine("User 2, guess the number.");

        int guess;

        do
        {
            Console.Write("What is your next guess? ");
            guess = int.Parse(Console.ReadLine()!);

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
