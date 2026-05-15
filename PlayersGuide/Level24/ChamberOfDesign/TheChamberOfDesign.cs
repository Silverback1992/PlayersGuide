using PlayersGuide.Level24.ChamberOfDesign.RockPaperScissors;

namespace PlayersGuide.Level24.ChamberOfDesign;

public static class TheChamberOfDesign
{
    public static void Solution()
    {
        Console.WriteLine("Rock, Paper, Scissors!");
        var player1 = new Player("Player 1");
        var player2 = new Player("Player 2");
        var game = new Game(10, player1, player2);
        game.Play();
    }
}
