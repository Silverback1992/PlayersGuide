namespace PlayersGuide.Notes.SubNotes.OverrideHelpers;

public class Base
{
    public virtual object CreateSomething()
    {
        return new Base();
    }

    public int Method() => 0;
}
