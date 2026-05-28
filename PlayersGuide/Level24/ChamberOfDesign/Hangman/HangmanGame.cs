using System.Text;

namespace PlayersGuide.Level24.ChamberOfDesign.Hangman;

public class HangmanGame
{
    private readonly HangmanDictionary _hangmanDictionary;
    private readonly StringBuilder _solution;
    private readonly string _word;
    private string _incorrectGuesses;
    private readonly HangmanPlayer _player;

    public HangmanGame()
    {
        _hangmanDictionary = new HangmanDictionary();
        _word = _hangmanDictionary.GetRandomWord();
        _solution = new StringBuilder(new string('_', _word.Length));
        _incorrectGuesses = string.Empty;
        _player = new HangmanPlayer();
    }

    public void Run()
    {
        while (true)
        {
            _player.DisplayStateOfTheGame(_solution.ToString(), _incorrectGuesses);
            string input = _player.PickLetter();

            if (input == "exit")
            {
                Console.WriteLine($"Thanks for playing! The word was '{_word}'.");
                break;
            }

            if (input.Length != 1 || !char.IsLetter(input[0]))
            {
                Console.WriteLine("Invalid input. Please enter a single letter or 'exit'.");
                continue;
            }

            char guess = char.ToLower(input[0]);
            bool correctGuess = false;

            for (int i = 0; i < _word.Length; i++)
            {
                if (char.ToLower(_word[i]) == guess)
                {
                    _solution[i] = _word[i];
                    correctGuess = true;
                }
            }

            if (!correctGuess)
            {
                Console.WriteLine($"Sorry, '{guess}' is not in the word.");
                _incorrectGuesses += guess;
            }

            if (!_solution.ToString().Contains('_'))
            {
                Console.WriteLine($"Congratulations! You've guessed the word '{_word}'!");
                break;
            }
        }
    }
}
