namespace PlayersGuide.Notes.SubNotes.DeconstructorsNotesHelpers;

public class Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public void Deconstruct(out decimal amount, out string currency)
    {
        amount = Amount;
        currency = Currency;
    }
}
