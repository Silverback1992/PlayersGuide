namespace PlayersGuide.Level24.ChamberOfDesign.Hangman;

public class HangmanDictionary
{
    private readonly List<string> _words;

    public HangmanDictionary()
    {
        _words =
        [
            "hangman",
            "programming",
            "challenge",
            "design",
            "dictionary",
            "solution",
            "player",
            "game",
            "word",
            "guess"
        ];
    }

    public string GetRandomWord()
    {
        var randomIndex = Random.Shared.Next(_words.Count);
        return _words[randomIndex];
    }
}
