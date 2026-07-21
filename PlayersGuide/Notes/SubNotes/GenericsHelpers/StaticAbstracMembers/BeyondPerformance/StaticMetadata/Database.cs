namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.StaticAbstracMembers.BeyondPerformance.StaticMetadata;

public class Database
{
    public void DeleteAll<T>() where T : IDatabaseModel
    {
        string sql = $"DELETE FROM {T.TableName}";
        ExecuteSql(sql);
    }

    private void ExecuteSql(string sql)
    {
        Console.WriteLine(sql);
    }
}
