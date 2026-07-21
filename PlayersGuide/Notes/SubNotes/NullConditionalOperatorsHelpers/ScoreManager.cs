namespace PlayersGuide.Notes.SubNotes.NullConditionalOperatorsHelpers;

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
