namespace PlayersGuide.Notes.SubNotes;

public static class NullableStructsNotes
{
    public static void Show()
    {
        Nullable<int> nullableInt = 32;
        // you can also use int?
        int? differentNullableInt = null;

        if (nullableInt.HasValue)
        {
            // ...
        }
    }
}
