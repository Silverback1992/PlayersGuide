namespace PlayersGuide.Level24.ChamberOfDesign.Hangman;

public class HangmanPlayer
{
    public string PickLetter()
    {
        Console.Write("Guess: ");
        string input = Console.ReadLine()!;
        return input;
    }

    public void DisplayStateOfTheGame(string solution, string incorrectGuesses)
    {
        Console.Write($"Word: {string.Join(" ", solution)}");
        Console.Write("| ");
        Console.Write($"Remaining: {solution.ToString().Count(c => c == '_')}");
        Console.Write("| ");
        Console.Write($"Incorrect guesses: {incorrectGuesses}");
        Console.Write("| ");
    }
}
