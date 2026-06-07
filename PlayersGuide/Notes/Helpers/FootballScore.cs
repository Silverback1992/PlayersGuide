namespace PlayersGuide.Notes.Helpers;

public class FootballScore
{
    private ScoreManager _scoreManager;

    public void InitScoreManager()
    {
        _scoreManager = new ScoreManager();
    }

    public string? GetTopPlayerName()
    {
        return _scoreManager?.GetScores()?[0]?.Name;
    }

    public string GetTopPlayerNameWithDefault()
    {
        return _scoreManager?.GetScores()?[0]?.Name ?? "(not found)";
    }

    public string GetTopPlayerNameWithDefaultWithCompoundAssignment()
    {
        string? name = _scoreManager?.GetScores()?[0]?.Name;
        name ??= "(not found)";
        return name;
    }
}
