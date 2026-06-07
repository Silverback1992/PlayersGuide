namespace PlayersGuide.Notes.Helpers;

public struct PairOfInts
{
    public int A;
    public int B;

    public void WriteSomething()
    {
        Console.WriteLine($"A: {A}, B: {B}");
    }
}
