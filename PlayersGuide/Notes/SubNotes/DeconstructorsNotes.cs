using PlayersGuide.Notes.SubNotes.DeconstructorsNotesHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class DeconstructorsNotes
{
    public static void Show()
    {
        var price = new Money(19.99m, "USD");
        var (amount, currency) = price;
    }
}
