namespace PlayersGuide.Notes.SubNotes.StructsHelpers;

public class CircleClass
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Radius { get; private set; }
    public CircleClass(double x, double y, double radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }
}
