namespace PlayersGuide.Notes.SubNotes.NullConditionalOperatorsHelpers;

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
        // The null coalescing operator takes an expression that might be null and provide a value or expression to use as a fallback if it is.
        // There's also the compound assignment operator ??= for this
        name ??= "(not found)";
        return name;
    }
}
