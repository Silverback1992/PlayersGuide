namespace PlayersGuide.Notes.SubNotes;

public static class YieldReturnNotes
{
    public static void Show()
    {
        Console.WriteLine("Yield return:");

        foreach (int n in Numbers())
        {
            Console.WriteLine($"got {n}");
        }

        Console.WriteLine();
        Console.WriteLine("First:");

        int first = Numbers().First();

        var someNumbers = Naturals().Take(5);
    }

    public static IEnumerable<int> Numbers()
    {
        Console.WriteLine("A");
        yield return 1; // hand back 1, then PAUSE here
        Console.WriteLine("B");
        yield return 2; // resume, hand back 2, PAUSE again
        Console.WriteLine("C");
        yield return 3;
    }

    public static IEnumerable<int> Naturals()
    {
        int n = 0;

        while (true)
        {
            yield return n++;
        }
    }
}
