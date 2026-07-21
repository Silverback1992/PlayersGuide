namespace PlayersGuide.Notes.SubNotes.NameHidingShadowingInConstructorsHelpers;

public class Person
{
    public string Name { get; set; } = "Derp";

    public Person(string Name)
    {
        Name = Name; // compiler warns!
    }
}
