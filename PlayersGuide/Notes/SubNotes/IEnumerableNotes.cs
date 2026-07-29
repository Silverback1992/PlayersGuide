using PlayersGuide.Notes.SubNotes.IEnumerableNotesHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class IEnumerableNotes
{
    public static void Show()
    {
        Console.WriteLine("IEnumerable:");

        // IEnumerable<T>: "I can be walked"
        // IEnumerator<T>: "I am a walk in progress"

        Console.WriteLine("Random words:");

        // Letting foreach do the walking for us
        var words = new List<string> { "apple", "banana", "cherry" };
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }

        Console.WriteLine();

        Console.WriteLine("Random words with Enumerator:");

        // Behind the scenes, foreach is using an enumerator to walk the collection
        var iterator = words.GetEnumerator();
        while (iterator.MoveNext())
        {
            string word = iterator.Current;
            Console.WriteLine(word);
        }

        Console.WriteLine();

        // IEnumerable<T> lazy vs ToList(): when and why
        // When to call ToList()
        // 1. Enumerate the result more than once
        var orders = new List<Order>()
        {
            new() { Total = 50 },
            new() { Total = 150 },
            new() { Total = 200 },
            new() { Total = 75 },
            new() { Total = 1300 },
            new() { Total = 25 },
        };
        IEnumerable<Order> myEnumerable = orders.Where(o => o.Total > 100);
        int count = myEnumerable.Count();
        var first = myEnumerable.First();
        Console.WriteLine("Random numbers:");
        foreach (var item in myEnumerable)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        // 2. You need a stable snapshot
        Console.WriteLine("Stable snapshot:");
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var evens = numbers.Where(x => x % 2 == 0); // ToList() would fix it
        Console.WriteLine(evens.Count());
        numbers.Add(6);
        Console.WriteLine(evens.Count()); // it increases here

        // 3. You need list-only abilities (indexing, Count, etc.)
        Console.WriteLine("List-only abilities:");
        var list = myEnumerable.ToList();
        Console.WriteLine(list[0]); // indexing
        Console.WriteLine(list.Count); // Count

        // Example of things going wrong with a db connection and IEnumerable<T> lazy evaluation
        IEnumerable<int> myNumbers;

        using (var conn = new FakeConnection())
        {
            myNumbers = conn.Query().Where(n => n % 2 == 0);
        } // conn.Dispose() runs here, _disposed = true

        //foreach (var item in myNumbers)
        //{
        //    Console.WriteLine(item); // throws ObjectDisposedException
        //}

        // When to leave it lazy
        // Streaming
        var someList = new List<int> { 5, 10, 15, 20, 25, 105, 115, 150 };
        var bigs = someList.Where(x => x > 100);
        foreach (var item in bigs)
        { }

        // Short circuiting
        var orders2 = new List<Order>()
        {
            new() { Total = 50 },
            new() { Total = 150 },
            new() { Total = 200 },
            new() { Total = 75 },
            new() { Total = 1300 },
            new() { Total = 25 },
        };

        var firstLargeOrder = orders2.Where(o => o.Total > 100).First(); // could of course use First(o => o.Total > 100) instead but this is just for demonstration purposes of short circuiting
    }
}
