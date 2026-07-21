namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.StaticAbstracMembers.OldApproach;

public static class StatCalculator
{
    public static void CalculateTotalDefense(List<ArmorStats> allArmorPieces)
    {
        // Boxing
        ICombinable total = new ArmorStats() { Defense = 0 };

        foreach (ArmorStats piece in allArmorPieces)
        {
            // boxing - CLR stops and boxes 'piece' into an ICombinable
            // boxing - inside the Add method the result is boxed to be returned as an ICombinable
            total = total.Add(piece);
        }
    }
}
