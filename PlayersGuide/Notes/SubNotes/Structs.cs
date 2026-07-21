using PlayersGuide.Notes.SubNotes.StructsHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class Structs
{
    public static void Show()
    {
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
    }
}
