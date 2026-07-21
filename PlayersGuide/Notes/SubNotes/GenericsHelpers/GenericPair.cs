namespace PlayersGuide.Notes.SubNotes.GenericsHelpers;

public class GenericPair<T1, T2>
{
    public T1 First { get; }
    public T2 Second { get; }

    public GenericPair(T1 first, T2 second)
    {
        First = first;
        Second = second;
    }
}
