namespace PlayersGuide.Notes.SubNotes.GenericsHelpers;

public static class GenericRepeater
{
    public static List<T> Repeat<T>(T value, int count)
    {
        var result = new List<T>();

        for (int i = 0; i < count; i++)
        {
            result.Add(value);
        }

        return result;
    }
}
