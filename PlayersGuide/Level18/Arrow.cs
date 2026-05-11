namespace PlayersGuide.Level18;

public class Arrow
{
    public Arrowhead Arrowhead { get; set; }
    public Fletching Fletching { get; set; }
    public int Shaft { get; set; }

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
}
