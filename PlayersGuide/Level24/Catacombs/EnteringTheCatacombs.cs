namespace PlayersGuide.Level24.Catacombs;

public static class EnteringTheCatacombs
{
    public static void Solution()
    {
        Console.WriteLine("Point class test:");

        var a = new Point(2, 3);
        Console.WriteLine($"({a.X}, {a.Y})");

        var b = new Point(-4, 0);
        Console.WriteLine($"({b.X}, {b.Y})");

        Console.WriteLine("Color class test:");

        var c1 = new Color(65, 21, 67);
        Console.WriteLine($"({c1.R}, {c1.G}, {c1.B})");

        Console.WriteLine($"({Color.Black.R}, {Color.Black.G}, {Color.Black.B})");

        Console.WriteLine("Card class test:");

        var deck = new List<Card>();

        foreach (var color in Enum.GetValues<CardColor>())
        {
            foreach (var rank in Enum.GetValues<CardRank>())
            {
                deck.Add(new Card(color, rank));
            }
        }

        deck.ForEach(x => Console.WriteLine($"The {x.Color} {x.Rank}"));

        Console.WriteLine("Door class test:");

        Console.WriteLine("Enter initial passcode:");

        string passcode = Console.ReadLine()!;

        var door = new Door(passcode);

        Console.Clear();

        Console.WriteLine("Choose an operation:");
        Console.WriteLine("\"status\" - Check the door status");
        Console.WriteLine("\"open\" - Open the door");
        Console.WriteLine("\"close\" - Close the door");
        Console.WriteLine("\"lock\" - Lock the door");
        Console.WriteLine("\"unlock\" - Unlock the door");
        Console.WriteLine("\"change\" - Change the passcode");
        Console.WriteLine("\"exit\" - Exit the program");

        string operation;

        do
        {
            operation = Console.ReadLine()!;

            switch (operation)
            {
                case "status":
                    Console.WriteLine($"The door is currently {door.DoorStatus}");
                    break;
                case "open":
                    door.Open();
                    break;
                case "close":
                    door.Close();
                    break;
                case "lock":
                    door.Lock();
                    break;
                case "unlock":
                    door.Unlock();
                    break;
                case "change":
                    Console.WriteLine("Enter the current passcode:");
                    string currentPasscode = Console.ReadLine()!;

                    Console.WriteLine("Enter the new passcode:");
                    string newPasscode = Console.ReadLine()!;

                    door.TryChangePasscode(currentPasscode, newPasscode);
                    break;
                case "exit":
                    break;
                default:
                    Console.WriteLine("Invalid operation. Please try again.");
                    break;
            }
        } while (operation != "exit");

        Console.Clear();
        Console.WriteLine("Password validator class test:");

        while (true)
        {
            Console.WriteLine("Enter a password to validate (or \"exit\" to quit):");

            string input = Console.ReadLine()!;

            if (input == "exit")
            {
                break;
            }

            PasswordValidator.ValidatePassword(input);
        }
    }
}
