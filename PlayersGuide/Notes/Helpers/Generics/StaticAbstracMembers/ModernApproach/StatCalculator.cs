namespace PlayersGuide.Notes.Helpers.Generics.StaticAbstracMembers.ModernApproach;

public class StatCalculator
{
    public T CombineAll<T>(List<T> stats) where T : ICombinable<T>
    {
        T total = T.Zero;

        foreach (var stat in stats)
        {
            total += stat;
        }

        return total;
    }
}
