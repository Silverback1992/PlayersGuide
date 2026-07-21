using System.Runtime.CompilerServices;

namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.UnmanagedGenericConstraint;

public class MemorySystem
{
    public void AllocateMemory<T>(T data) where T : unmanaged
    {
        int byteSize = Unsafe.SizeOf<T>();
        Console.WriteLine($"This type takes exactly {byteSize} bytes of memory.");
    }
}
