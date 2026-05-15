using PlayersGuide.Level13;

namespace PlayersGuide.Level18;

public static class VinFletchersArrows
{
    public static void Solution()
    {
        Console.WriteLine("Select arrow creation method:");
        Console.WriteLine("1. Elite Arrow");
        Console.WriteLine("2. Beginner Arrow");
        Console.WriteLine("3. Marksman Arrow");
        Console.WriteLine("4. Custom Arrow");

        Console.Write("Enter your choice (1-4): ");
        string choice = Console.ReadLine()!;

        var arrow = choice switch
        {
            "1" => Arrow.CreateEliteArrow(),
            "2" => Arrow.CreateBeginnerArrow(),
            "3" => Arrow.CreateMarksmanArrow(),
            "4" => CreateCustomArrow(),
            _ => throw new ArgumentException("Invalid choice. Please select a number between 1 and 4.")
        };

        float cost = arrow.GetCost();

        Console.WriteLine($"Cost of the arrow: {cost}");
    }

    private static Arrow CreateCustomArrow()
    {
        Console.WriteLine("Please enter the parameters for the arrow:");

        Console.Write("Arrowhead (Steel, Wood, Obsidian): ");
        string arrowheadInput = Console.ReadLine()!;

        Console.Write("Fletching type (Plastic, TurkeyFeathers, GooseFeathers): ");
        string fletchingInput = Console.ReadLine()!;

        int shaftLength = TakingANumber.AskForNumberInRange("Shaft length (in centimeters): ", 60, 100);

        return new Arrow(Enum.Parse<Arrowhead>(arrowheadInput), Enum.Parse<Fletching>(fletchingInput), shaftLength);
    }
}
