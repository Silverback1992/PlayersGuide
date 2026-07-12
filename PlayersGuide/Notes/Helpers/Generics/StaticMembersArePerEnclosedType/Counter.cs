namespace PlayersGuide.Notes.Helpers.Generics.StaticMembersArePerEnclosedType;

public class Counter<T>
{
    public static int Count;   // "one shared value"... per closed type

    public Counter() => Count++;
}
