namespace PlayersGuide.Notes.SubNotes.StaticConstructorsHelpers;

public class Dog
{
    public static readonly string Name;
    public static readonly string Description;

    static Dog()
    {
        Name = "Rover";
        Description = "A friendly dog.";
    }
}
