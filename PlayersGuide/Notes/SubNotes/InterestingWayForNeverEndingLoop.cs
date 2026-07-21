namespace PlayersGuide.Notes.SubNotes;

public static class InterestingWayForNeverEndingLoop
{
    public static void Show()
    {
        Console.WriteLine("Interesting way for never ending loop:");

        for (; ; )
        {
            Console.WriteLine("This loop will run forever!");
            Console.WriteLine("asd");
            break; // Just to prevent an actual infinite loop in this example
        }
    }
}
