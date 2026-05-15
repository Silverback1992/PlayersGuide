namespace PlayersGuide.Level24.ChamberOfDesign.RockPaperScissors;

public class Game
{
    public int NumberOfRounds { get; }
    public Player Player1 { get; }
    public Player Player2 { get; }
    public (int Player1Score, int Player2Score) Score { get; private set; }

    public Game(int numberOfRounds, Player player1, Player player2)
    {
        NumberOfRounds = numberOfRounds;
        Player1 = player1;
        Player2 = player2;
    }

    public void Play()
    {
        for (int i = 1; i <= NumberOfRounds; i++)
        {
            Console.WriteLine($"Round {i}");
            Player1.SetHand();
            Player2.SetHand();

            var round = new Round(i);
            var winner = round.DetermineWinner(Player1, Player2);

            if (winner == null)
            {
                Console.WriteLine("It's a tie!");
            }

            if (winner == Player1)
            {
                Console.WriteLine($"{Player1.Name} wins this round!");
                Score = (Score.Player1Score + 1, Score.Player2Score);
            }

            if (winner == Player2)
            {
                Console.WriteLine($"{Player2.Name} wins this round!");
                Score = (Score.Player1Score, Score.Player2Score + 1);
            }

            Console.WriteLine($"Score: {Player1.Name}: {Score.Player1Score}, {Player2.Name}: {Score.Player2Score}");

            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing!");
        Console.WriteLine($"Final Score: {Player1.Name}: {Score.Player1Score}, {Player2.Name}: {Score.Player2Score}");
    }
}
