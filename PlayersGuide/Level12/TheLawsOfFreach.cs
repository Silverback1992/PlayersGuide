namespace PlayersGuide.Level12;

public static class TheLawsOfFreach
{
    public static void Solution()
    {
        var array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

        int smallest = array[0];

        foreach (int i in array)
        {
            if (i < smallest)
            {
                smallest = i;
            }
        }

        Console.WriteLine($"The smallest number is: {smallest}");

        int total = 0;

        foreach (int i in array)
        {
            total += i;
        }

        float avg = (float)total / array.Length;

        Console.WriteLine($"The average is: {avg}");
    }
}
