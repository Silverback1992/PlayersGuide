namespace PlayersGuide.Notes.Helpers.Generics.StaticAbstracMembers.BeyondPerformance.StaticMetadata;

public class Enemy : IDatabaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public static string TableName => "Enemies";
}
