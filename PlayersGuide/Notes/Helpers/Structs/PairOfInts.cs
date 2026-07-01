namespace PlayersGuide.Notes.Helpers.Structs;

public struct PairOfInts
{
    public int A;
    public int B;

    public void WriteSomething()
    {
        Console.WriteLine($"A: {A}, B: {B}");
    }
}
