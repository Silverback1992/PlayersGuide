namespace PlayersGuide.Notes.SubNotes;

public static class Composition
{
    public static void Show()
    {
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
        // The goal: building modular, reusable behaviors. It is heavily used as an alternative to Inheritance (which is an "is-a" relationship like a Dog is an Animal)
    }
}
