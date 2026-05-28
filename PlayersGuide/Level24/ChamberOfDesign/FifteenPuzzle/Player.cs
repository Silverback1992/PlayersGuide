namespace PlayersGuide.Level24.ChamberOfDesign.FifteenPuzzle;

public class Player
{
    public Board Board { get; }

    public Player(int size)
    {
        Board = BoardGenerator.Generate(size);
    }

    public void Play()
    {
        while (true)
        {
            Console.WriteLine("Current board:");
            PrintBoard();

            if (Board.IsSolved())
            {
                Console.WriteLine($"Congratulations! You solved the puzzle in {Board.NumberOfMoves} moves!");
                break;
            }

            Console.WriteLine("Enter a direction to move (up, down, left, right) or 'exit' to quit:");
            string input = Console.ReadLine()!;

            if (input == "exit")
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }

            if (Enum.TryParse<Direction>(input, true, out var direction))
            {
                Board.Move(direction);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'up', 'down', 'left', 'right', or 'exit'.");
            }
        }
    }

    private void PrintBoard()
    {
        for (int i = 0; i < Board.State.GetLength(0); i++)
        {
            for (int j = 0; j < Board.State.GetLength(1); j++)
            {
                Console.Write(Board.State[i, j]?.ToString() ?? " ");
                Console.Write(" \t");
            }
            Console.WriteLine();
        }
    }
}
