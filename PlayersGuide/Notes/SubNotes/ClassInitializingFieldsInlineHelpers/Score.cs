namespace PlayersGuide.Notes.SubNotes.ClassInitializingFieldsInlineHelpers;

public class Score
{
    public string Name = "Unknown";
    public int Points = 0;
    public int Level = 1;

    public Score()
    {
        // Name here is Unknown
        Name = "Something else";
        // Name now is Something else
    }
}
