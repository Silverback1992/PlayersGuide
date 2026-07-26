namespace PlayersGuide.Notes.SubNotes.WhyStringsImmutableHelpers;

public static class MyMethods
{
    public static void DoSomething(string name)
    {
        name = "asd";
    }

    public static void DoSomething(Enemy enemy)
    {
        enemy.Health = 50;
    }
}
