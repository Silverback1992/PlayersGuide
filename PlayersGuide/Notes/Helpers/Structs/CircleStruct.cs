namespace PlayersGuide.Notes.Helpers.Structs;

public struct CircleStruct
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Radius { get; private set; }

    public CircleStruct(double x, double y, double radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }
}
