using PlayersGuide.Notes.SubNotes.NameHidingShadowingInConstructorsHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class NameHidingShadowingInConstructors
{
    public static void Show()
    {
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
    }
}
