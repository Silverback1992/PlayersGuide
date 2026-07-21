namespace PlayersGuide.Notes.SubNotes;

public static class MemoryManagement
{
    public static void Show()
    {
        // The stack
        // When a method is called enough space is reserved for its local variables and parameters (its stack frame).
        // When you return from a method space is reclaimed and reused.
        // The stack's memory management strategy is most straightforward when data is always a known size.

        // The heap
        // When data is needed a free spot in memory is found.
        // A reference is used to keep track of objects placed on the heap.

        // The garbage collector has the task of inspecting things on the heap to see if they are still in use.
        // If not it lets the heap memory be reused.
    }
}
