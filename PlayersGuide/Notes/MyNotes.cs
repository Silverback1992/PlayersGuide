using PlayersGuide.Notes.Helpers;
using PlayersGuide.Notes.Helpers.Boxing;
using PlayersGuide.Notes.Helpers.ClassInitializingFieldsInline;
using PlayersGuide.Notes.Helpers.Cloning;
using PlayersGuide.Notes.Helpers.Enums;
using PlayersGuide.Notes.Helpers.Generics;
using PlayersGuide.Notes.Helpers.Generics.MultipleGenericConstraints;
using PlayersGuide.Notes.Helpers.Generics.NakedTypeConstraints;
using PlayersGuide.Notes.Helpers.NameHiding;
using PlayersGuide.Notes.Helpers.NewKeyword;
using PlayersGuide.Notes.Helpers.NullConditionalOperators;
using PlayersGuide.Notes.Helpers.NumericLiteralSuffixes;
using PlayersGuide.Notes.Helpers.Records;
using PlayersGuide.Notes.Helpers.StaticConstructors;
using PlayersGuide.Notes.Helpers.Structs;
using PlayersGuide.Notes.Helpers.ThisKeyword;
using PlayersGuide.Notes.Helpers.UpcastingDowncasting;
using PlayersGuide.Notes.Helpers.WithStatement;

namespace PlayersGuide.Notes;

public static class MyNotes
{
    public static void Show()
    {
        #region Object-oriented principles

        // #1: Encapsulation: Combining data (fields) and the operations on that data (methods) into a well-defined unit (like a class).
        // #2: Information hiding: only the object itself should directly access it's data
        // #3: Abstraction: the outside world does not need to know each object or class's inner workings and can deal with it as an abstract concept. Abstraction allows the inner workings to change without affecting the outside world.
        // #4: Inheritance: basing one class on another, retaining the original class's functionality while extending the new class with additional capabilities.
        // #5: Polymorphism: derived classes can override methods from the base class. The correct version is determined at runtime, so you'll get different behavior depending on the object's class.

        #endregion

        Console.WriteLine();

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

        #endregion

        Console.WriteLine();

        #region Class-initializing fields inline

        // Check Score class in Helpers folder

        var tetrisScore = new Score();

        // The field assignments happen after the memory is zeroed out but before any constructor code runs.
        // These then become the default values for these fields.
        // Any constructor can override these defaults as needed.

        #endregion

        Console.WriteLine();

        #region Name hiding (shadowing) in constructors

        Console.WriteLine("Name hiding (shadowing) in constructors:");

        // When a method or constructor parameter has the exact same name as a class level field or property, the parameter "hides" (or shadows) the field.
        // Inside that constructor, whenever you type that name the compiler assumes you mean the parameter.

        // The problem (name = name;)
        // Because the compiler assumes you are talking about the most local variable (the parameter) typing name = name is useless.
        // - You are literally taking the parameter's value and assigning it right back to the parameter
        // - The actual class field is completely ignored and remains at its default value.

        // this keyword: like a special variable that always refers to the object you are currently in.

        // Check Person class in Helpers folder
        var person = new Person("Alice");
        Console.WriteLine($"Name hiding (shadowing) in constructors check: {person.Name}");

        #endregion

        Console.WriteLine();

        #region Calling other constructors with this

        Console.WriteLine("Calling other constructors with this:");

        // Check City class in Helpers folder

        var defaultCity = new City();
        Console.WriteLine($"Default city check: {defaultCity.Name} {defaultCity.ZipCode}");

        #endregion

        Console.WriteLine();

        #region Getters and Setters

        // getters: methods that retrive a field's current value
        // setters: methods that assign a new value to a field

        #endregion

        Console.WriteLine();

        #region Static constructors

        Console.WriteLine("Static constructors:");

        // If a class has static fields or properties you may need to run some logic to initialize them.
        // To address this, you could define a static constructor.

        // A static constructor cannot have parameters, nor can you call it directly.
        // Instead it runs automatically the first time you use the class.
        // Because of this you cannot place an accessibility modifier like public or private on it.

        // Check Dog class in Helpers folder
        Console.WriteLine($"Dog static constructor check: {Dog.Name}");

        #endregion

        Console.WriteLine();

        #region null-conditional operators

        Console.WriteLine("null-conditional operators:");

        // The ?. amd ?[] operators can be used in place of . and [] to simultaneously check for null and access member:

        // Check the FootballPlayerScore class in the Helpers folder for an example of this in action.
        var footballScore = new FootballScore();
        string? topPlayer = footballScore.GetTopPlayerName();

        Console.WriteLine($"Top player name check: {topPlayer}");

        // Both ?. and ?[] evaluate the part before it to see if it is null. 
        // If it is, then no further evaluation happens and the whole expression evaluates to null.
        // If it is not null evaluation will continue as though it had been a normal . or [] operator.

        // So in the GetTopPlayerMethod if _scoreManager is null then the code returns a null value without calling GetScores.
        // If GetScore() returns null the above code returns a null without accessing index 0.

        #endregion

        Console.WriteLine();

        #region the null-coalescing operator

        // The null coalescing operator takes an expression that might be null and provide a value or expression to use as a fallback if it is.
        // There's also the compound assignment operator ??= for this

        // Check the FootballScore class in the Helpers folder for an example of this in action.

        #endregion

        Console.WriteLine();

        #region Shallow copy vs deep copy vs reference copy

        Console.WriteLine("Shallow copy vs deep copy vs reference copy:");

        // Shallow copy vs deep copy
        // The difference between the 2 only matters when you're dealing with nested reference types
        // (like an array of classes or a class that has another class as a property).

        // Shallow copy
        // - what it does: it creates a brand new container (the top level) but it does not create new copes of the nested objects inside.
        // Instead it just copies the references (pointers) to these inner objects.
        // - the result: you have 2 different boxes, but they are holding the exact same items.
        // If you reach into the copy's box and modify an item, the original object sees that modification too because they share the same inner items in memory.
        // - how it happens: in C# myArray[..], Array.Copy(), and Object.MemberwiseClone() all create shallow copies.

        // Deep copy
        // - what it does: it creates a brand new container AND is recursively goes inside and creates brand new completely independent copies of every single nested object, array or property.
        // - the result: you have 2 completely disconnected data structures
        // Modifying anything in the copy is guaranteed to never affect the original
        // - how it happens: C# does not have built in support for deep copying, because it's computationally expensive and complex.
        // Developers usually implement deep copies manually by writing a Clone() method or by serializing the object to JSON and immediately deserializing it into a new object

        // The entire concept revolves around the difference between Values types (like int, bool, struct) and Reference types (like class, arrays, lists)
        // Imagine you have a Hero class. Inside that hero you have an int Health = 100 and a reference to an Armor class object

        // The shallow clone: when you do a shallow clone in C# (usually by calling the built in MemberwiseClone() method) the computer creates a new Hero box.
        // It literally copes the int Health = 100 over to the new box.
        // But for the Armor object it does not create a new armor it just copies the memory address (the reference).
        // the danger: both the Original Hero and the Clones Hero are now wearing the exact same physical suit of armor.
        // If the Original Hero takes damage and their armor breaks the Cloned Hero's armor instantly breaks too, because they are pointing to the exact same object in memory.

        // The deep clone: a deep clone is something you usually have to write yourself.
        // - it creates a new Hero box
        // - it copies the int Health = 100
        // - it looks at the Armor goes into the memory heap, creates a brand new Armor object, copies the stats over and gives that new armor to the clone
        // the result: the Original and the Clone are completely independent. What happens to one does not affect the other.

        // Check Hero and Armor classes in the Helpers folder for an example of this in action.

        var hero = new Hero();
        var shallowClone = hero.CreateShallowClone();
        shallowClone.MyArmor.Durability = 0;

        Console.WriteLine($"Checking original armor value after changing shallow clone's armor: {hero.MyArmor.Durability}");

        var otherHero = new Hero();
        var deepClone = otherHero.CreateDeepClone();
        deepClone.MyArmor.Durability = 0;

        Console.WriteLine($"Checking original armor value after changing deep clone's armor: {otherHero.MyArmor.Durability}");

        // Clone vs Copy (terminology)
        // Why do we use both words?
        // "copy" is the universal COmputer Science term
        // "clone" is heavily used in the C# world specifically. This is because Microsoft built-in shallow copy method MemberwiseClone() and they created a built-in interface called ICloneable

        // Reference copy vs shallow copy
        // Reference copy (Hero b = a;)
        // the reality: you did not create a second Hero. There's still only one Hero object sitting in memory.
        // the analogy: think of the object on the heap as a physical Television. The variable a is a remote control pointing at that TV
        // When you write Hero b = a; you are not making a copy of the TV. You are just grabbing another remote control and pointing it at the same TV.
        // the result: if you press the "mute" button on remote b, remota a sees that the TV is muted. They are indentical.


        // The shallow copy (Hero b = a.CreateShallowClone();)
        // the reality: you did create a brand new parent object. There are now 2 Hero objects sitting in memory.
        // the difference: the compute ractually goes to the heap builds a new Hero box and copies the basic statis (like Health) over
        // It only gets "shallow" when dealing with nested objects (like Armor) where both Heroes end up sharing the same suit of armor.
        // the result: because there are 2 distinct Hero boxes chaning the Health of Hero b does not change the Health of Hero a.

        var someHero = new Hero();
        var referenceCopy = someHero;
        referenceCopy.Health = 50;

        Console.WriteLine($"Checking original health value after changing reference copy's health: {someHero.Health}");

        var andAnotherHero = new Hero();
        var shallowCopy = andAnotherHero.CreateShallowClone();
        shallowCopy.Health = 50;

        Console.WriteLine($"Checking original health value after changing shallow copy's health: {andAnotherHero.Health}");

        #endregion

        Console.WriteLine();

        #region Inheritance & constructors

        // When you create a derived class it is fundamentally built on top of the base class
        // Because of this the base class must be fully constructed in memory before the derived class can be constructed.

        // The invisible default
        // If your base class has no constructors defined, C# gives it an invisible parameterless constructor.
        // When your derived class is created, C# secretly calls base() behind the scenes.

        // The strict base (:base)
        // Once you define a custom constructor in a base class with parameters, C# deletes the invisible default constructor.
        // Now the base class requires data to be built.
        // Because the base must be built first, the derived class is forced to collect the necessary data and pass it up to the base constructor using the :base syntax.

        // Check Entity and Player classes in the Helpers folder for an example of this in action.

        var player = new Player(10, "SomeName");

        #endregion

        Console.WriteLine();

        #region Upcasting vs downcasting

        // Upcasting (automatic, implicit)
        // what it is: moving up the inheritance chain (from Player to Entity)
        // why it's automatic: it is 100% safe. A Player is an Entity.
        // It contains all the exact same fields and properties as Entity has plus some extra.
        // The compiler knows it can never fail so it does it for you silently.

        // The object on the heap is a Player object.
        // The compiler with the somEntity variable looks at the object through the lens of an Entity
        // That is why you can't access the Name property

        var player2 = new Player(10, "AnotherName");
        player2.Id = 10;
        Entity someEntity = player2; // upcasting from Player to Entity
        someEntity.Id = 5; // we can still access the Entity's Id property because Player inherits from Entity

        Console.WriteLine(player2.Id);

        // Downcasting (manual/explicit)
        // what it is: moving down the inheritance chain (from Entity to Player)
        // why it's manual: it is dangerous. The compiler looks at the Entity variable and says 
        // "I know its an Entity but is it a Player? Or is it an Enemy? Or a Chest? I can't gurantee this is safe!
        // Therefore it forces you to explicitly tell it "trust me I know what I'm doing"

        Entity entity = new Player(10, "DowncastName");

        // 3 ways to check entity type at runtime

        // 1. GetType() method: returns the exact runtime type of the object. If you compare it to typeof(Player) you can check if it's a Player.
        if (entity.GetType() == typeof(Player))
        {
            Player downcastPlayer1 = (Player)entity;
        }

        // 2. as operator: attempts to cast the object to the specified type. If the cast is successful, it returns the object as that type. If it fails, it returns null instead of throwing an exception.
        var downcastPlayer2 = entity as Player;

        if (downcastPlayer2 != null)
        {
            // We are guranteed that downcastPlayer2 is a Player here because if the cast had failed it would have been assigned null
        }

        // 3. is operator: checks if the object is of a certain type. It returns true if the object is of that type or a derived type, and false otherwise.
        if (entity is Player downcastPlayer3)
        {
            // We are guranteed that downcastPlayer3 is a Player here because the is operator checks the type before assigning it to the variable
        }

        #endregion

        Console.WriteLine();

        #region Override

        // When a normal (non-virtual) method is called, the compiler can determine which method to call at compile time.
        // When a method is virtual, it cannot. Instead it records some metadata in the compiled code to know what to look up as it is running.

        // An overrding method must match the name and parameters (both count and type) as the overriden method.
        // However you can use a more specific type for the return value if you want.
        // Check the Base and Derived classes in the Helpers folder for an example of this in action.

        #endregion

        Console.WriteLine();

        #region new

        Console.WriteLine("new:");

        // If a derived class defines a member whose name matches something in a base class without overriding it a new member will be reated which hides (instead of overrides) the base class member.
        // This is nearly always an accident caused by forgetting the override keyword. The compiler assumes as much and gives you a warning for it.

        // In the rare cases where this was by design you can tell the compiler it was intentional by adding the new keyword to the member in the derived class.

        // When a new member is defined unline polymorphism the behaviour depends on the type of the variable involved not the instance's type.
        Derived derived = new();
        Base myBase = derived;
        Console.WriteLine($"Derived and base check: {derived.Method} {myBase.Method}");

        #endregion

        Console.WriteLine();

        #region structs

        Console.WriteLine("Structs:");

        // Reference types such as a class can be null. In these cases the memory for an object doesn't exist until it is explicitly created by calling a constructor with the new keyword.
        // For value types like structs we don't have that option. The variable's mere existence means its memory must also exist even before it has been initialized by a constructor.

        // While a constructor can be used to intialize data, invoking a constructor is not always necessary.
        PairOfInts pair;
        pair.A = 10;
        Console.WriteLine($"Struct check: {pair.A}");

        // In C# a struct is not considered "definitely assigned" until every one of its fields has a value. Until then the compiler restricts what you can do.
        var otherPair = new PairOfInts();
        otherPair.WriteSomething();

        PairOfInts unitializedPair;
        // unitializedPair.WriteSomething(); // Compiler error: Use of unassigned local variable 'unitializedPair'
        unitializedPair.A = 5;
        unitializedPair.B = 8;
        unitializedPair.WriteSomething();

        // Inheritance does not work well when copying value types around so structs do not support it.
        // A struct cannot pick a base class (they all derive from ValueType which derives from object).
        // Structs are allowed to implement interfaces.
        // Object slicing => why structs don't support inheritance: when you copy a derived class into a base class variable, the extra data in the derived class gets "sliced" off and lost. This is a problem for value types because they are copied around so much. If structs supported inheritance this would be a common source of bugs and confusion.

        // The way struct and classes are managed in memory is also a driving force.
        // Reference types like classes always get allocated individually on the heap.
        // Structs get allocated directly in whatever contains them.
        // That is sometimes the stack and sometimes a larger object on the heap (such as an array or class with value-type fields).
        // Therefore instances of classes make the GC work harder while structs don't

        // Performace where structs shine:
        for (int i = 0; i < 1000000; i++)
        {
            CircleStruct myStruct = new(0, 0, 10);
        }

        for (int i = 0; i < 1000000; i++)
        {
            CircleClass myClass = new(0, 0, 10);
        }

        // Performance where classes shine:
        var myStruct2 = new CircleStruct(0, 0, 10);
        var myClass2 = new CircleClass(0, 0, 10);

        for (int i = 0; i < 1000000; i++)
        {
            Displayer.DisplayStruct(myStruct2);
        }

        for (int i = 0; i < 1000000; i++)
        {
            Displayer.DisplayClass(myClass2);
        }

        // In short you should consider a struct when you have a type that:
        // - is focused on data instead of behaviour
        // - is small in size
        // - where you don't need shared references
        // - when being a value type works to your advantage instead of againts you
        // If any of these is not true you should prefer a class

        // Rules to follow when making structs
        // - keep them small. That is subjective but an 8-byte struct is fine while a 200 byte struct should be avoided.
        // - make structs immutable. Structs should represent a single compound value and as such you should make its fields readonly and not have setters (not even private) for its properties.
        // - because struct values can exist without calling a constructor a default, zeroed-out struct should represent a valid value

        // Object slicing - why structs are sealed
        // Setup: Enemy struct with 2 int fields Health Speed (8 bytes total)
        // Boss derived struct with 1 int field Damage (4 bytes total)
        // Boss is 12 bytes total. If you copy a Boss into an Enemy variable the extra 4 bytes of Damage will be sliced off and lost. This is a problem for value types because they are copied around so much. If structs supported inheritance this would be a common source of bugs and confusion.

        #endregion

        Console.WriteLine();

        #region Built-in type aliases

        // The built in types that are value types are not just value types but structs themselves.
        // While rarely used we could refer to them with their full names instead of the aliases. For example we could use System.Int32 instead of int, System.Boolean instead of bool, System.String instead of string, etc.
        Int32 myInt = new();

        #endregion

        Console.WriteLine();

        #region Boxind and unboxing

        object thing = 3; // Boxing: the int value 3 is being boxed into an object
        int unboxedThing = (int)thing; // unboxing

        // same can happen with structs and interfaces
        ISomeInterface someInterface = new SomeStruct(); // Boxing: the struct is being boxed into an interface
        SomeStruct unboxedStruct = (SomeStruct)someInterface; // unboxing

        #endregion

        Console.WriteLine();

        #region Records

        Console.WriteLine("Records:");

        var pointA = new Point(1, 2);
        //pointA.X = 3; // Compiler error: Cannot modify because Point is a record and is immutable

        // string representation of a record is automatically generated for us
        Console.WriteLine($"Point A: {pointA}");

        // Value semantics: two records with the same data are considered equal
        var pointB = new Point(1, 2);
        Console.WriteLine($"Point A == Point B: {pointA == pointB}");

        // Deconstruction: we can deconstruct a record into its individual values
        var (extractedX, extractedY) = pointA;
        Console.WriteLine($"Extracted X: {extractedX}, Extracted Y: {extractedY}");

        // with statement
        var pointC = pointA with { X = 3 }; // creates a new record with the same data as pointA but with X changed to 3

        // Note: with can be used with records, structs and anonymous types
        var coolStruct = new CoolStruct();
        var coolStruct2 = coolStruct with { CoolPropertyA = 3 }; // creates a new struct with the same data as coolStruct but with CoolPropertyA changed to 3

        var anonymousUser = new { Name = "John", Age = 30 };
        var copiedUser = anonymousUser with { Age = 31 }; // creates a new anonymous type with the same data as anonymousUser but with Age changed to 31

        #endregion

        Console.WriteLine();

        #region Generics

        Console.WriteLine("Generics:");

        var customNumbersList = new CustomGenericList<int>();
        customNumbersList.Add(1);
        customNumbersList.Add(2);

        // Multiple generic type parameters
        var genericPair = new GenericPair<int, string>(5, "Hello");

        // Generic method
        var words = GenericRepeater.Repeat("Hello", 3);

        // Generic type constraints
        var myConstrainedList = new ConstraitedList<GameObject>();
        var trollEnemy = new Troll()
        {
            ID = 1,
        };
        myConstrainedList.Add(trollEnemy);

        // Constrainting several generic type parameters
        var manager = new LootManager();
        var myPaladin = new Paladin();

        // We pass the Paladin instance, and tell it to generate a LegendarySword
        manager.GrantLoot<Paladin, LegendarySword>(myPaladin);

        // Naked type constraints: we can use the generic type parameter itself as a constraint for another generic type parameter
        var system = new InventorySystem();
        var entityList = new List<Helpers.Generics.NakedTypeConstraints.Entity>();
        var playerEntity = new Helpers.Generics.NakedTypeConstraints.Player();
        var sword = new Sword();

        system.AddToList(entityList, playerEntity);
        // system.AddToList(entityList, sword); Compiler error: Sword does not satisfy the constraint of being an Entity

        #endregion

        Console.WriteLine();
    }
}
