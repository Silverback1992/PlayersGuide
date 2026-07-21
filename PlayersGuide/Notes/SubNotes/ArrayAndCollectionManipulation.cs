namespace PlayersGuide.Notes.SubNotes;

public static class ArrayAndCollectionManipulation
{
    public static void Show()
    {
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
    }
}
