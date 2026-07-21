using PlayersGuide.Notes.SubNotes.NullConditionalOperatorsHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class NullConditionalOperators
{
    public static void Show()
    {
        Console.WriteLine("null-conditional operators:");

        // The ?. amd ?[] operators can be used in place of . and [] to simultaneously check for null and access member:

        // Check the FootballPlayerScore class in the Helpers folder for an example of this in action.
        var footballScore = new FootballScore();
        string? topPlayer = footballScore.GetTopPlayerName();

        Console.WriteLine($"Top player name check: {topPlayer}");

        // Both ?. and ?[] evaluate the part before it to see if it is null. 
        // If it is, then no further evaluation happens and the whole expression evaluates to null.
        // If it is not null evaluation will continue as though it had been a normal . or [] operator.

        // So in the GetTopPlayerMethod if _scoreManager is null then the code returns a null value without calling GetScores.
        // If GetScore() returns null the above code returns a null without accessing index 0.
    }
}
