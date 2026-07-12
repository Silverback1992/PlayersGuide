namespace PlayersGuide.Notes.Helpers.Generics.StaticAbstracMembers.OldApproach;

public class ArmorStats : ICombinable
{
    public int Defense;

    public ICombinable Add(ICombinable other)
    {
        // Unboxing
        ArmorStats otherArmorStats = (ArmorStats)other;

        var newStats = new ArmorStats() { Defense = this.Defense + otherArmorStats.Defense };

        // Boxing
        return newStats;
    }
}
