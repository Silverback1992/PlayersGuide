namespace PlayersGuide.Notes.SubNotes.IEnumerableNotesHelpers;

public class FakeConnection : IDisposable
{
    private bool _disposed = false;
    private readonly List<int> _data = new() { 1, 2, 3, 4, 5 };

    public IEnumerable<int> Query()
    {
        foreach (var item in _data)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(FakeConnection), "Cannot read: the connection is closed.");
            }
            yield return item;
        }
    }

    public void Dispose() => _disposed = true;
}
