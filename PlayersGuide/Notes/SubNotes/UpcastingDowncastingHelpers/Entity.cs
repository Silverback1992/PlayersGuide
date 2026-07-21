namespace PlayersGuide.Notes.SubNotes.UpcastingDowncastingHelpers;

public class Entity
{
    public int Id { get; set; }

    // No default constructor exists anymore. We require an id.
    public Entity(int id)
    {
        Id = id;
    }
}
