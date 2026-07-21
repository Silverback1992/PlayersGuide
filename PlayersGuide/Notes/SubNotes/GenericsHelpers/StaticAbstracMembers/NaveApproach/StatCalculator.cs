namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.StaticAbstracMembers.NaveApproach;

public class StatCalculator
{
    public T CombineAll<T>(List<T> stats)
    {
        T total = default;

        foreach (var stat in stats)
        {
            // total = total + stat; Compile error
        }

        return total;
    }
}
