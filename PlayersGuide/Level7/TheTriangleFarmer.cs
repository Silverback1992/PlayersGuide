namespace PlayersGuide.Level7;

public static class TheTriangleFarmer
{
    public static void Solution()
    {
        Console.WriteLine("Triangle's base:");
        float baseLength = float.Parse(Console.ReadLine()!);

        Console.WriteLine("Triangle's height:");
        float height = float.Parse(Console.ReadLine()!);

        float area = (baseLength * height) / 2.0f;
        Console.WriteLine($"The area of the triangle is: {area}");
    }
}
