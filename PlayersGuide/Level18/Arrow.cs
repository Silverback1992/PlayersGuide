namespace PlayersGuide.Level18;

public class Arrow
{
    public Arrowhead Arrowhead { get; }
    public Fletching Fletching { get; }
    public int Shaft { get; }

    public Arrow(Arrowhead arrowhead, Fletching fletching, int shaft)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Shaft = shaft;
    }

    public float GetCost()
    {
        int arrowheadCost = Arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5,
            _ => throw new ArgumentOutOfRangeException()
        };

        int fletchingCost = Fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3,
            _ => throw new ArgumentOutOfRangeException()
        };

        float shaftCost = Shaft * (float)0.05;

        return arrowheadCost + fletchingCost + shaftCost;
    }

    public static Arrow CreateEliteArrow() => new(Arrowhead.Steel, Fletching.Plastic, 95);
    public static Arrow CreateBeginnerArrow() => new(Arrowhead.Wood, Fletching.GooseFeathers, 75);
    public static Arrow CreateMarksmanArrow() => new(Arrowhead.Steel, Fletching.TurkeyFeathers, 65);
}
