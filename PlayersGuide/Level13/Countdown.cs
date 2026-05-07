namespace PlayersGuide.Level13;

public static class Countdown
{
    public static void Solution(int x)
    {
        if (x == 0)
        {
            return;
        }

        Console.WriteLine(x);
        Solution(x - 1);
    }
}
