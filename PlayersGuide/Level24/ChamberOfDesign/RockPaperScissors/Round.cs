namespace PlayersGuide.Level24.ChamberOfDesign.RockPaperScissors;

public class Round
{
    public int Index { get; }

    public Round(int idx)
    {
        Index = idx;
    }

    public Player DetermineWinner(Player player1, Player player2)
    {
        if (player1.CurrentHand == player2.CurrentHand)
        {
            return null!;
        }

        if ((player1.CurrentHand == Hand.Rock && player2.CurrentHand == Hand.Scissors) ||
            (player1.CurrentHand == Hand.Paper && player2.CurrentHand == Hand.Rock) ||
            (player1.CurrentHand == Hand.Scissors && player2.CurrentHand == Hand.Paper))
        {
            return player1;
        }

        return player2;
    }
}
