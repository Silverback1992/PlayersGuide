using PlayersGuide.Level13;

namespace PlayersGuide.Level12;

public static class TheReplicatorOfDto
{
    public static void Solution()
    {
        var myArr = new int[5];

        Console.WriteLine("Please enter 5 numbers:");

        for (int i = 0; i < myArr.Length; i++)
        {
            myArr[i] = TakingANumber.AskForANumber($"Number {i + 1}: ");
        }

        var otherArr = new int[myArr.Length];

        for (int i = 0; i < myArr.Length; i++)
        {
            otherArr[i] = myArr[i];
        }

        Console.WriteLine("Values of old array:");

        for (int i = 0; i < myArr.Length; i++)
        {
            Console.WriteLine(myArr[i]);
        }

        Console.WriteLine("Values of new array:");

        for (int i = 0; i < otherArr.Length; i++)
        {
            Console.WriteLine(otherArr[i]);
        }
    }
}
