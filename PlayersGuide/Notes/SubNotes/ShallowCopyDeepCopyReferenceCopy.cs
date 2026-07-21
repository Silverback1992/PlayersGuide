using PlayersGuide.Notes.SubNotes.ShallowCopyDeepCopyReferenceCopyHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class ShallowCopyDeepCopyReferenceCopy
{
    public static void Show()
    {
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
    }
}
