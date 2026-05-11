using PlayersGuide.Level13;

namespace PlayersGuide.Level18;

public static class VinFletchersArrows
{
    public static void Solution()
    {
        Console.WriteLine("Please enter the parameters for the arrow:");

        Console.Write("Arrowhead (Steel, Wood, Obsidian): ");
        string arrowheadInput = Console.ReadLine()!;

        Console.Write("Fletching type (Plastic, TurkeyFeathers, GooseFeathers): ");
        string fletchingInput = Console.ReadLine()!;

        int shaftLength = TakingANumber.AskForNumberInRange("Shaft length (in centimeters): ", 60, 100);

        var arrow = new Arrow()
        {
            Arrowhead = Enum.Parse<Arrowhead>(arrowheadInput),
            Fletching = Enum.Parse<Fletching>(fletchingInput),
            Shaft = shaftLength
        };

        float cost = arrow.GetCost();

        Console.WriteLine($"Cost of the arrow: {cost}");
    }
}
