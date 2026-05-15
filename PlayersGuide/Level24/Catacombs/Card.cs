namespace PlayersGuide.Level24.Catacombs;

public class Card
{
    public CardColor Color { get; }
    public CardRank Rank { get; }

    public Card(CardColor color, CardRank rank)
    {
        Color = color;
        Rank = rank;
    }

    public bool IsNumberCard => Rank is >= CardRank.One and <= CardRank.Ten;
}
