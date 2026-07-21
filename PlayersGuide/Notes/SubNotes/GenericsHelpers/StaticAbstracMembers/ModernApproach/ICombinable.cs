namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.StaticAbstracMembers.ModernApproach;

public interface ICombinable<T> where T : ICombinable<T>
{
    static abstract T operator +(T left, T right);
    static abstract T Zero { get; }
}
