namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.StaticMembersArePerEnclosedType;

public class Counter<T>
{
    public static int Count;   // "one shared value"... per closed type

    public Counter() => Count++;
}
