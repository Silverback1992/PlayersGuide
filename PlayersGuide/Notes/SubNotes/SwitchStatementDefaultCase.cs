namespace PlayersGuide.Notes.SubNotes;

public static class SwitchStatementDefaultCase
{
    public static void Show()
    {
        Console.WriteLine("Switch statement default case:");

        // In a classic switch statement , the default case doesn't have to be at the end. You can put it anywhere in the switch block.
        int anotherChoice = 4;
        switch (anotherChoice)
        {
            default:
                Console.WriteLine("Default case");
                break;
            case 1:
                Console.WriteLine("Case 1");
                break;
            case 2:
                Console.WriteLine("Case 2");
                break;
        }

        // With switch expressions order matters strictly.
        // Compiler error:

        //Action myAction = anotherChoice switch
        //{
        //    _ => () => Console.WriteLine("Default case"),
        //    1 => () => Console.WriteLine("Case 1"),
        //    2 => () => Console.WriteLine("Case 2"),
        //};

        //myAction();
    }
}
