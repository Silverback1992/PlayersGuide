namespace PlayersGuide.Notes.SubNotes;

public static class Tuples
{
    public static void Show()
    {
        Console.WriteLine("Tuples:");

        // Tuples are value types!

        // Tuple example
        (string, int, int) myTuple = ("R2-D2", 12420, 15);
        var anotherTuple = ("Example", 10, 20);

        // You can access the elements like so
        Console.WriteLine("Tuple element check:");
        Console.WriteLine($"Name: {myTuple.Item1} Level: {myTuple.Item3} Score: {myTuple.Item2}");

        // Different ways to use names in tuples
        (string Name, int Points, int Level) namedTuple = ("R2-D2", 12420, 15);
        var varNamedTuple = (Name: "R2-D2", Points: 12420, Level: 15);

        Console.WriteLine("Named tuple element check:");
        Console.WriteLine($"Name: {namedTuple.Name} Level: {namedTuple.Level} Score: {namedTuple.Points}");
        Console.WriteLine($"Name: {varNamedTuple.Name} Level: {varNamedTuple.Level} Score: {varNamedTuple.Points}");

        // You are not required to give a name to every tuple member. 
        // Any unnamed item will keep its original ItemN name.
        var mixedTuple = (Name: "R2-D2", 12420, Level: 15); //same thing if you write it like (string Name, int, int Level) mixedTuple = ("R2-D2", 12420, 15);
        Console.WriteLine("Mixed tuple element check:");
        Console.WriteLine($"Name: {mixedTuple.Name} Level: {mixedTuple.Level} Score: {mixedTuple.Item2}");

        // If you do not use var then the names will not be inferred and any name supplied when you declared the variable would be used:
        (string, int P, int L) weirdTuple = (Name: "R2-D2", 12420, 15); // compiler even warns you!
        Console.WriteLine("The heck is this weird tuple:");
        Console.WriteLine($"Name: {weirdTuple.Item1} Level: {weirdTuple.L} Score: {weirdTuple.P}");

        // Deconstruction
        // A way to take all of the parts of a tuple and place them into separate variables in one line of code.
        (string extractedName, int extractedPoints, int extractedLevel) = myTuple;

        // One use case for tuple deconstruction is swapping values without needing a temporary variable.
        // The two variables' contents are copied over to a new tuple and then copied back to the original variables in the opposite order.
        // The result is that the values of the two variables are swapped without needing to create a temporary variable to hold one of the values during the swap.
        int swapThis = 10;
        int swapThat = 20;
        (swapThis, swapThat) = (swapThat, swapThis);

        // You can use discard to ignore certain elements of a tuple when deconstructing it.
        // This is useful when you only care about some of the values in the tuple and want to ignore the rest.
        // The _ is a discard variable. The compiler will invent a name for it behind the scenes so the code can work, but it won't clutter up the code with useless names and leads to more readable code.
        (string extractedName2, int extractedPoints2, _) = myTuple;

        // Tuples and equality
        // Two tuples are considered equal if all of their corresponding elements are equal.
        var tuple1 = (X: 2, Y: 4);
        var tuple2 = (U: 2, V: 4);
        Console.WriteLine($"Tuple equality check: {tuple1 == tuple2}");

        // Tuple pattern matching
        // Normally a switch statement evaluates a single variable.
        // Tuple pattern matching allows you to combine multiple variables into a temporary Tuple (var1, var2) and evaluate them simultaneously in a single switch expression.
        // How to think about it:
        // Think of it like building a "truth table" or a multi-column lookup grid.
        // You are asking the compiler: "if column A is this and column B is this, what is the result?"
        string color = "red";
        string shape = "circle";

        string itemDescription = (color, shape) switch
        {
            ("red", "circle") => "This is a red circle.",
            ("red", "square") => "This is a red square.",
            ("blue", "circle") => "This is a blue circle.",
            ("blue", "square") => "This is a blue square.",
            _ => "Unknown item."
        };

        // Tuple size can be anything it's not limited to just 2

        // Advanced tuple pattern matching
        (string color2, string shape2, string size2) = ("red", "circle", "small");

        string otherDescription = (color2, shape2, size2) switch
        {
            ("red", "circle", "small") => "This is a small red circle.",
            ("red", "circle", _) => "This is a red circle of unknown size.",
            ("red", _, _) => "This is a red item of unknown shape and size.",
            _ => "Unknown item."
        };
    }
}
