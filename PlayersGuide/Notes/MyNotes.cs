using PlayersGuide.Notes.Helpers;

namespace PlayersGuide.Notes;

public static class MyNotes
{
    public static void Show()
    {
        #region Variable Declarations

        // Multiple variable declarations
        int a, b, c;

        // Multiple variable declarations with initialization
        int x = 1, y = 2, z;

        // Chained assignment
        int k, l, m;
        k = l = m = 10;

        #endregion

        Console.WriteLine();

        #region Digital Separators for Readability

        // The digital separator for readability
        int bigNumber = 1_000_000_000;

        #endregion

        Console.WriteLine();

        #region Numeric Literal Suffixes

        Console.WriteLine("Numeric Literal Suffixes:");

        // When you write 
        ulong aVeryBigNumber = 10000000000;
        // you are taking a long literal and letting the compiler implicitly convert it to ulong.
        // The compiler allows this because it knows 10 billion fits within the range of ulong.

        // Adding the UL simply skips the impilict conversion step.
        // You are telling the compiler "Don't guess. Treat this raw number as a ulong literal right away."
        ulong bVeryBigNumber = 10_000_000_000UL;

        // This matters because:
        // 1. Variables declared with var.
        var bigNumber1 = 10000000000; // bigNumber1 is of type long
        var bigNumber2 = 10_000_000_000UL; // bigNumber2 is of type ulong

        // 2. Method overloads that take different numeric types.
        MyMath.DoMath(100); // Calls DoMath(int)
        MyMath.DoMath(100L); // Calls DoMath(long)

        // 3. Math overflow trap
        unchecked
        {
            long result = 2000000000 + 2000000000; // This will cause an overflow if treated as int
            Console.WriteLine($"Unchecked overflow example: {result}");
        }

        unchecked
        {
            long result = 2000000000L + 2000000000; // This will cause an overflow if treated as int
            Console.WriteLine($"Overflow fixed with suffix: {result}");
        }

        #endregion

        Console.WriteLine();

        #region Binary and Hexadecimal Literals

        Console.WriteLine("Binary and Hexadecimal Literals:");

        // Binary literals start with 0b
        int thirteen = 0b00001101; // 13 in binary
        Console.WriteLine($"Binary literal: {thirteen}");

        // Hexadecimal literals start with 0x
        int theColorMagenta = 0xFF00FF; // RGB hex code for magenta
        Console.WriteLine($"Hexadecimal literal: {theColorMagenta}");

        #endregion

        Console.WriteLine();

        #region Char Deep Dive

        Console.WriteLine("Char Deep Dive:");

        // C# uses UTF-16 encoding for char literals
        // This means a char is 2 bytes and can represent a wide range of Unicode characters.
        // If you know the hex code for a Unicode character, you can use it in a char literal.
        char aLetter = '\u0061'; // Unicode for 'a'
        Console.WriteLine($"Character literal: {aLetter}");

        // UTF-16 means it can represent 65535 characters directly, but for characters outside the Basic Multilingual Plane (BMP), it uses surrogate pairs.
        // Surrogate pairs (high and low surrogates) mean that some characters are represented by two char values.
        // For example 🚀
        // This is why you can't put the rocket emoji directly in a char literal, because it requires two char values to represent it in UTF-16.
        // It also means that if you check the length of a string containing the rocket emoji, it will be 2, not 1, because it's made up of two char values.
        string rocketEmoji = "🚀";
        Console.WriteLine($"Rocket emoji length: {rocketEmoji.Length}");

        // This also produces some weird results when you check if the characters in the string are letters, because the surrogate pairs are not considered letters.
        foreach (char myChar in rocketEmoji)
        {
            Console.WriteLine($"Is letter: {char.IsLetter(myChar)}");
        }

        // The modern fix for this is the Rune type, which represents a Unicode scalar value and can handle all Unicode characters without needing surrogate pairs.
        Console.WriteLine($"Rune count: {("🚀".EnumerateRunes().Count())}");

        // Today the world agrees on the Unicode standard.
        // The encodings that are used to represent Unicode characters in memory are UTF-8, UTF-16, and UTF-32.
        // The numbers don't refer to the number of bits in the character, but rather the number of bits used to encode each code point. Or puzzle piece.
        // UTF-32: minimum puzzle piece size is 32 bits (4 bytes). It can represent all Unicode characters directly so every character uses exactly 1 puzzle piece. (fixed width encoding)
        // UTF-16: minimum puzzle piece size is 16 bits (2 bytes). It can represent characters in the BMP directly with one puzzle piece, but characters outside the BMP require two puzzle pieces (surrogate pairs). (variable width encoding)
        // UTF-8: minimum puzzle piece size is 8 bits (1 byte). It uses a variable number of bytes to encode each character, from 1 to 4 bytes. It can represent all Unicode characters, but the number of bytes used depends on the character. (variable width encoding)


        // Programming language divide
        // Different languages chose different encodings for their string types, which has led to a divide in the programming world.
        // UTF-16 era languages C#, Java, JavaScript. Invented when 16 bits seemed enough forever. Fast for CPUs but permanently stuck with surrogate pairs for characters outside the BMP.
        // UTF-8 era languages Rust, Go, Swift. Highly memory efficient but trades away CPU speed (the computer has to manually scan strings left to right to find the start of each character).
        // UTF-32 trickster: Python. Normally uses 1 byte but the moment you insert an emoji it secretly upgrades the entire string in memory to UTF-32 (4 bytes per character).

        // If you want the memory efficiency of UTF-8 in C# you can force it by adding the u8 suffix to a string.
        // Standard UTF-16 (takes 10 bytes)
        string hello = "Hello";
        // Highly compressed UTF-8 (takes 5 bytes)
        ReadOnlySpan<byte> helloUtf8 = "Hello"u8;

        // The above example takes 5 bytes because each character in "Hello" is an ASCII character, which can be represented in a single byte in UTF-8. 
        // In contrast, the standard UTF-16 encoding uses 2 bytes for each character, resulting in a total of 10 bytes for the same string.

        // However if we go back to emojis and attempt to use UTF-8, we see that the memory usage is actually worse than UTF-16.
        // And we also again can't trust our "eyes" to count characters
        ReadOnlySpan<byte> utf8Ogre = "👹"u8;
        Console.WriteLine($"UTF-8 Length: {utf8Ogre.Length}");

        #endregion

        Console.WriteLine();

        #region Floating Point Types

        Console.WriteLine("Floating Point Types:");

        // Floating point types
        // Type     Bytes       Digits of Precision
        // float    4           7
        // double   8           15-16
        // decimal  16          28-29
        float myFloat = 1.55555555555555555f; // 7 digits of precision
        Console.WriteLine($"Float precision check: {myFloat}");
        double myDouble = 1.555555555555555555555555555555555555555555555555555; // 15-16 digits of precision
        Console.WriteLine($"Double precision check: {myDouble}");
        decimal myDecimal = 1.55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555m; // 28-29 digits of precision
        Console.WriteLine($"Decimal precision check: {myDecimal}");

        // The precision is a range because the maximum binary value in memory doesn't end in a perfect string of 9s.
        // The lower number in the range (e.g. 28 for decimal) is the number of digits that are guaranteed to be accurate,
        // while the upper number (e.g. 29 for decimal) is the maximum number of digits that can be stored but only if the number doesn't exceed the binary limits.

        #endregion

        Console.WriteLine();

        #region Scientific Notation

        Console.WriteLine("Scientific Notation:");

        // Floating point literals can embed e or E in a number
        double avogadrosNumber = 6.022e23; // 6.022 x 10^23
        Console.WriteLine($"Avogadro's number: {avogadrosNumber}");

        #endregion

        Console.WriteLine();

        #region Formatting Extras

        Console.WriteLine("Formatting Extras:");

        // Any 0 in the format indicates that you want a number to appear there even if the number isn't strictly necessary.
        Console.WriteLine($"{42:000.000}");

        // In contrast a # will leave a place for a digit but will not display anything if the number doesn't have a digit in that place.
        Console.WriteLine($"{42:###.###}");
        Console.WriteLine($"{42.1294:#.##}");

        // You can also use the % symbol to make a number be represented as a percent instead of a fraction.
        Console.WriteLine($"{4f / 9f:0.0%}");

        #endregion

        Console.WriteLine();

        #region Switch Expressions

        int myChoice = 2;
        string response = myChoice switch
        {
            1 => "You chose option 1",
            2 => "You chose option 2",
            3 => "You chose option 3",
            _ => "Invalid choice"
        };

        #endregion

        Console.WriteLine();

        #region Interesting way for never ending loop

        Console.WriteLine("Interesting way for never ending loop:");

        for (; ; )
        {
            Console.WriteLine("This loop will run forever!");
            Console.WriteLine("asd");
            break; // Just to prevent an actual infinite loop in this example
        }

        #endregion

        Console.WriteLine();

        #region Switch statement default case

        Console.WriteLine("Switch statement default case:");

        // In a classic switch statement , the default case doesn't have to be at the end. You can put it anywhere in the switch block.
        int anotherChoice = 4;
        switch (anotherChoice)
        {
            default:
                Console.WriteLine("Default case");
                break;
            case 1:
                Console.WriteLine("Case 1");
                break;
            case 2:
                Console.WriteLine("Case 2");
                break;
        }

        // With switch expressions order matters strictly.
        // Compiler error:

        //Action myAction = anotherChoice switch
        //{
        //    _ => () => Console.WriteLine("Default case"),
        //    1 => () => Console.WriteLine("Case 1"),
        //    2 => () => Console.WriteLine("Case 2"),
        //};

        //myAction();

        #endregion

        Console.WriteLine();

        #region Array and collection manipulation

        Console.WriteLine("Array and Collection Manipulation:");

        Console.WriteLine("Index operator:");

        int[] numbers = { 1, 2, 3, 4, 5 };
        // ^1 is the last eleement
        Console.WriteLine($"Last element: {numbers[^1]}");
        // ^2 is the second to last element
        Console.WriteLine($"Second to last element: {numbers[^2]}");
        // ^0 represents the "past-the-end" boundary (which is equal to the length of the array)
        // Console.WriteLine($"Past-the-end element: {numbers[^0]}"); // This will throw an IndexOutOfRangeException

        Console.WriteLine();

        Console.WriteLine("The range operator: .. (slicing)");
        // The range operator allows you to create a slice of an array or collection.
        // The syntax is start..end
        // The most important thing to remember is that the end index is exclusive, meaning it does not include the element at the end index.

        // This will give you a new array containing the elements from index 1 to index 3 (4 is exclusive)
        var slice1 = numbers[1..4];
        // This will give you a new array containing the elements from the start of the array to index 2 (3 is exclusive)
        var slice2 = numbers[..3];
        // This will give you a new array containing the elements from index 2 to the end of the array.
        // This is equal to 2..^0
        var slice3 = numbers[2..];
        // This gets everything except the first and last element
        var slice4 = numbers[1..^1];
        // This makes a shallow copy of the entire array
        var slice5 = numbers[..];

        Console.WriteLine();

        Console.WriteLine("Collection expressions & the spread operator ..");

        // Instead of using verbose syntax like new int[] { 1, 2 } or new List<int> { 1, 2 }, you can just use brackets []
        int[] myArray = [1, 2, 3];
        List<int> myList = [1, 2, 3];

        // Paired with the spread operator .. you can inline multiple collections dynamically.
        int[] evens = [2, 4, 6];
        int[] odds = [1, 3, 5];
        int[] allNumbers = [.. evens, .. odds, 7, 8, 9];

        Console.WriteLine();

        Console.WriteLine("List patterns (pattern matching)");
        // You can also use .. inside switch statements or is expressions to match againts the "shape" of a collection.
        // The .. here acts like a "slice pattern" meaning "any number of elements can go here".

        int[] scores = [100, 85, 90, 75];
        bool startsWith100 = scores is [100, ..]; // Matches if the first element is 100, regardless of the rest of the elements
        bool endsWith75 = scores is [.., 75]; // Matches if the last element is 75, regardless of the preceding elements
        bool specificShape = scores is [100, _, 90, ..]; // Matches if the first element is 100, an any value in the second element, 90 in the third element, and any number of elements after that

        #endregion

        Console.WriteLine();

        #region Default values for arrays

        // When you create an array of a certain type, all the elements are automatically initialized to the default value for that type.
        int[] intArray = new int[5]; // All elements are initialized to 0

        #endregion

        Console.WriteLine();

        #region Multi-dimensional arrays

        int[,] matrix = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

        #endregion

        Console.WriteLine();

        #region Jagged arrays

        // Jagged array: arrays of arrays are most often used when each of the smaller arrays needs to be a different size.
        int[][] modernJagged =
        [
            [1, 2, 3],
            [4, 5],
            [6, 7, 8, 9]
        ];

        #endregion

        Console.WriteLine();

        #region Enumeration Facts

        Console.WriteLine("Enumeration Facts:");

        // First item you list will be the enumeration's default value.
        var mySeason = new Season();
        Console.WriteLine($"Enumeration default value check: {mySeason}");

        // Default underlying type is int, but you can specify a different integral type if you want.
        // Check OtherSeason enum

        // If you want you can assign custom numbers
        // Check CustomSeason enum

        // Any enumeration member without an assigned number is automatically given the one after the member before it.
        // Check AutoSeason enum
        var myAutoSeason = AutoSeason.Spring;
        Console.WriteLine($"Autoincrement enum value check: {myAutoSeason:D}");

        #endregion

        Console.WriteLine();

        #region Memory Management

        // The stack
        // When a method is called enough space is reserved for its local variables and parameters (its stack frame).
        // When you return from a method space is reclaimed and reused.
        // The stack's memory management strategy is most straightforward when data is always a known size.

        // The heap
        // When data is needed a free spot in memory is found.
        // A reference is used to keep track of objects placed on the heap.

        // The garbage cikkectir has the task of inspecting things on the heap to see if they are still in use.
        // If not it lets the heap memory be reused.

        #endregion

        Console.WriteLine();

        #region Semantics

        // Value semantics: means two things are equal if their data elements are equal.
        // Reference semantics: means two tings are equal if they're the same location in memory.

        #endregion

        Console.WriteLine();

        #region Composition

        // 2 contexts, 1 concept

        // 1. General data composition (compositve types)
        // What it is: the fundamental act of grouping primitive types like (int, bool, char) or
        // other simple types together into a single logical unit.
        // Example: a tuple (int x, int y) or a basic struct Point { int X; int Y; }
        // The goal: combining simple data elements so you can pass them around as one single "thing" instead of managing multiple separate variables.

        // 2. Object-oriented composition (the "has-a" relationship)
        // What it is: a specific architectural design principle where complex classes are built by
        // giving them fields/properties of other class types
        // Example: a Car class having an Engine field and a SteeringWheel field. (A Car has an Engine.)
        // The goal: building modular, reusable behaviors. It is heavily used as an alternative to Inheritance (which is an "is-a" relationship like a Dog is an Aniaml)

        #endregion

        Console.WriteLine();

        #region Tuples

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

        #endregion

        Console.WriteLine();
    }
}
