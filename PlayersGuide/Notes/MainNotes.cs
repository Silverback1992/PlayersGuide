using PlayersGuide.Notes.SubNotes;

namespace PlayersGuide.Notes;

public static class MainNotes
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

        VariableDeclarations.Show();
        DigitalSeparatorsForReadability.Show();
        NumericLiteralSuffixes.Show();
        Console.WriteLine();
        BinaryAndHexadecimalLiterals.Show();
        Console.WriteLine();
        CharDeepDive.Show();
        Console.WriteLine();
        FloatingPointTypes.Show();
        Console.WriteLine();
        ScientificNotation.Show();
        Console.WriteLine();
        FormattingExtras.Show();
        Console.WriteLine();
        InterestingWayForNeverEndingLoop.Show();
        Console.WriteLine();
        SwitchExpressions.Show();
        SwitchStatementDefaultCase.Show();
        Console.WriteLine();
        ArrayAndCollectionManipulation.Show();
        Console.WriteLine();
        MultiDimensionalArrays.Show();
        JaggedArrays.Show();
        EnumerationFacts.Show();
        Console.WriteLine();
        MemoryManagement.Show();
        Semantics.Show();
        Composition.Show();
        Tuples.Show();
        Console.WriteLine();
        ClassInitializingFieldsInline.Show();
        NameHidingShadowingInConstructors.Show();
        Console.WriteLine();
        CallingOtherConstructorsWithThis.Show();
        Console.WriteLine();
        GettersAndSetters.Show();
        StaticConstructors.Show();
        Console.WriteLine();
        NullConditionalOperators.Show();
        Console.WriteLine();
        ShallowCopyDeepCopyReferenceCopy.Show();
        Console.WriteLine();
        InheritanceAndConstructors.Show();
        UpcastingDowncasting.Show();
        Console.WriteLine();
        Override.Show();
        New.Show();
        Console.WriteLine();
        Structs.Show();
        Console.WriteLine();
        BuiltInTypeAliases.Show();
        BoxingUnboxing.Show();
        Records.Show();
        Console.WriteLine();
        Generics.Show();
        Console.WriteLine();


        // Same instant, two places on Earth:
        DateTimeOffset utc = new(2024, 6, 1, 12, 0, 0, TimeSpan.Zero);      // 12:00 +00:00
        DateTimeOffset budapest = new(2024, 6, 1, 14, 0, 0, TimeSpan.FromHours(2)); // 14:00 +02:00
        var myDateTimeOffSet = DateTimeOffset.Now;

        Console.WriteLine(utc == budapest);   // True  ← same MOMENT in time

        TimeOnly opens = new(9, 0), closes = new(17, 30);
        var now = TimeOnly.FromDateTime(DateTime.Now);
        now.IsBetween(opens, closes);

        Console.WriteLine();

        int? myNullableInt = 3;

        var myDateTime = new DateTime(2024, 6, 1, 12, 0, 0);
        var myDateTime2 = new DateTime(2024, 6, 1, 14, 0, 0);
        var asd = myDateTime2 - myDateTime;
        var dsa = myDateTime + asd;

        IEnumerable<int> myEnumerable = new List<int> { 1, 2, 3, 4, 5 };
        int count = myEnumerable.Count();
        int first = myEnumerable.First();
        foreach (var item in myEnumerable)
        {
            Console.WriteLine(item);
        }

        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var evens = numbers.Where(x => x % 2 == 0);
        Console.WriteLine(evens.Count());
        numbers.Add(6);
        Console.WriteLine(evens.Count());

        var words = new List<string> { "apple", "banana", "cherry" };
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }

        var iterator = words.GetEnumerator();
        while (iterator.MoveNext())
        {
            string word = iterator.Current;
            Console.WriteLine(word);
        }
    }
}
