namespace PlayersGuide.Level10;

public static class DiscountedInventory
{
    public static void Solution()
    {
        Console.WriteLine("The following items are available:");
        Console.WriteLine("1 - Rope");
        Console.WriteLine("2 - Torches");
        Console.WriteLine("3 - Climbing Equipment");
        Console.WriteLine("4 - Clean Water");
        Console.WriteLine("5 - Machete");
        Console.WriteLine("6 - Canoe");
        Console.WriteLine("7 - Food Supplies");

        Console.Write("What number do you want to see the price off? ");
        int number = int.Parse(Console.ReadLine()!);

        Console.WriteLine("What is your name?");
        string name = Console.ReadLine()!;

        int price = number switch
        {
            1 => 10,
            2 => 15,
            3 => 25,
            4 => 1,
            5 => 20,
            6 => 200,
            7 => 1,
            _ => 0
        };

        string item = number switch
        {
            1 => "Rope",
            2 => "Torches",
            3 => "Climbing Equipment",
            4 => "Clean Water",
            5 => "Machete",
            6 => "Canoe",
            7 => "Food Supplies",
            _ => "Unknown Item"
        };

        if (name == "GG")
        {
            Console.WriteLine("Discounted price!");
            Console.WriteLine($"{item} costs {price * 0.5}");
            return;
        }

        Console.WriteLine($"{item} costs {price}");
    }
}
