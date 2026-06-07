namespace PlayersGuide.Notes.Helpers;

public class Base
{
    public virtual object CreateSomething()
    {
        return new Base();
    }

    public int Method() => 0;
}
