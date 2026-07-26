using PlayersGuide.Notes.SubNotes.ExtensionMethodsNotesHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class ExtensionMethodsNotes
{
    public static void Show()
    {
        Console.WriteLine("Extension Methods notes:");

        string myShout = "no surrender".Shout();
        Console.WriteLine(myShout);

        string myAlternating = "Hueueueueueueue".ToAlternating();
        Console.WriteLine(myAlternating);

        var even = new[] { 1, 2, 3, 4, 5, 6 }.WhereEven();

        var orders = new List<Order>()
        {
            new() { Total = 300 },
            new() { Total = 1500 },
            new() { Total = 1200 },
            new() { Total = 800 }
        };

        var bigOrders = orders.Filter(o => o.Total > 1000);

        // every type implementing that interface works
        var myList = new List<int>() { 1, 2, 3 };
        var myArray = new int[] { 1, 2 };

        if (myList.IsEmpty())
        {
            // ..
        }

        if (myArray.IsEmpty())
        {
            // ..
        }

        // Enum extension
        Priority p = Priority.Critical;

        if (p.RequiresImmediateAction())
        {
            Console.WriteLine(p.ToDisplayString());
        }
    }
}
