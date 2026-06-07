namespace PlayersGuide.Notes.Helpers;

public class Derived : Base
{
    public new int Method() => 4;

    public override Derived CreateSomething()
    {
        return new Derived();
    }
}
