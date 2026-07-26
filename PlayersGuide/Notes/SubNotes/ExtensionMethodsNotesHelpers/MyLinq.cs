namespace PlayersGuide.Notes.SubNotes.ExtensionMethodsNotesHelpers;

public static class MyLinq
{
    public static IEnumerable<int> WhereEven(this IEnumerable<int> source)
    {
        foreach (int n in source)
        {
            if (n % 2 == 0)
            {
                yield return n;
            }
        }
    }

    public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (T item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static bool IsEmpty<T>(this IEnumerable<T> source) => !source.Any();
}
