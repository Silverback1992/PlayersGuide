namespace PlayersGuide.Notes.SubNotes.StructsHelpers;

public struct PairOfInts
{
    public int A;
    public int B;

    public void WriteSomething()
    {
        Console.WriteLine($"A: {A}, B: {B}");
    }
}
