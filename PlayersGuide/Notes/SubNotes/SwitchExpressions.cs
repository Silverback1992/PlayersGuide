namespace PlayersGuide.Notes.SubNotes;

public static class SwitchExpressions
{
    public static void Show()
    {
        int myChoice = 2;
        string response = myChoice switch
        {
            1 => "You chose option 1",
            2 => "You chose option 2",
            3 => "You chose option 3",
            _ => "Invalid choice"
        };
    }
}
