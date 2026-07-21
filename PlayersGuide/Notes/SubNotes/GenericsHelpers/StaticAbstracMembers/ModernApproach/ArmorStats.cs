namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.StaticAbstracMembers.ModernApproach;

public readonly struct ArmorStats : ICombinable<ArmorStats>
{
    public int PhysicalDef { get; init; }
    public int MagicDef { get; init; }

    public static ArmorStats Zero => new() { PhysicalDef = 0, MagicDef = 0 };

    public static ArmorStats operator +(ArmorStats left, ArmorStats right)
    {
        return new ArmorStats
        {
            PhysicalDef = left.PhysicalDef + right.PhysicalDef,
            MagicDef = left.MagicDef + right.MagicDef
        };
    }
}
