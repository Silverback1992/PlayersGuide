namespace PlayersGuide.Level4;

public static class TheThingNamer3000
{
    public static void Solution()
    {
        /*
         * The Thing Namer 3000 is a program that generates names for things based on user input. 
         * It asks the user for the type of thing and a description, then combines them with some fixed text to create a name.
         */

        Console.WriteLine("What kind of thing are we talking about?");
        string? a = Console.ReadLine(); // Read the type of thing from the user
        Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
        string? b = Console.ReadLine(); // Read the description of the thing from the user
        string c = "of Doom"; // A fixed suffix to add to the name"
        string d = "3000"; // A fixed number to add to the name

        Console.WriteLine("The " + b + " " + a + " " + c + " " + d + "!");

        // What would make this code better is better variable names
    }
}
