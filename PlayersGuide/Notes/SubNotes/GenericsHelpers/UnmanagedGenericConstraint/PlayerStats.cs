namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.UnmanagedGenericConstraint;

public struct PlayerStats
{
    public byte Level;       // 1 byte
    // [3 BYTES OF INVISIBLE PADDING ADDED BY JIT]
    public int Health;       // 4 bytes
}
