using PlayersGuide.Notes.SubNotes.WhyStringsImmutableHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class WhyStringsImmutable
{
    public static void Show()
    {
        Console.WriteLine("Why Strings are immutable:");

        Console.WriteLine("Theme A - safety");

        string name = "Gabor";
        MyMethods.DoSomething(name);
        Console.WriteLine(name); // "Gabor" - guaranteed

        // Contrast to mutable reference types:

        var troll = new Enemy { Health = 100 };
        MyMethods.DoSomething(troll); // this method can change troll's health
        Console.WriteLine(troll.Health); // .. no idea what this prints unless you look into the method

        Console.WriteLine("Equality by state");

        string a = "abc";
        string b = "ab" + "c";
        Console.WriteLine(a == b);

        // immutability makes them safe dictionary keys

        var dict = new Dictionary<string, int>();

        dict["abc"] = 42;
        Console.WriteLine(dict["ab" + "c"]);

        Console.WriteLine("Theme B - Optimization");

        string s1 = "hello";
        string s2 = "hello";

        // This might now always work but it looks cool:

        unsafe
        {
            fixed (char* p = s1)
                Console.WriteLine((long)p);   // an actual address

            fixed (char* x = s2)
                Console.WriteLine((long)x);   // an actual address
        }

        string k = "Claude";
        string l = "Claude";
        string m = "Claud" + "e";           // compile-time folded → same literal
        string part = "Claud";
        string n = part + "e";              // runtime concat → different object

        Console.WriteLine(ReferenceEquals(k, l));  // True  — interned, same object
        Console.WriteLine(ReferenceEquals(k, m));  // True  — folded to "Claude", interned
        Console.WriteLine(ReferenceEquals(k, n));  // False — separate heap object
        Console.WriteLine(k == n);                 // True  — same CONTENT (== compares chars)

        // Copying is free

        string original = "something";
        string copy = original; // why clone sth nobody can change?

        // Shared internal state

        string anotherOne = "Claude";
        string sub = anotherOne.Substring(2); // different heap object

        // but..

        ReadOnlySpan<char> slice = anotherOne.AsSpan(2);
        Console.WriteLine(slice);

        unsafe
        {
            fixed (char* p = anotherOne)
                Console.WriteLine((long)p);   // an actual address

            fixed (char* x = slice)
                Console.WriteLine((long)x);   // an actual address
        }

        Console.WriteLine();

        Console.WriteLine("Theme C - conceptual: values shouldn't mutate");

        DateTime christmans = new(2024, 12, 25);
        DateTime later = christmans.AddMonths(1);
        // christmas is unchanged: you didn't "move" Christmas, you got a different date

        // Same concept with string
        string lastOne = "Jon".ToUpper(); // doesn't change what "Jon" is, it produces a different string
    }
}
