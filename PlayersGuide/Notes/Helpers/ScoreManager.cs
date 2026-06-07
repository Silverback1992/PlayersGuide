namespace PlayersGuide.Notes.Helpers;

public class ScoreManager
{
    public List<FootballPlayer> GetScores()
    {
        var players = new List<FootballPlayer>()
        {
            new() {  Name = "David"},
            new() { Name = "Sarah" },
            new() { Name = "John" },
            new() { Name = "Emily" },
        };

        return players;
    }
}
