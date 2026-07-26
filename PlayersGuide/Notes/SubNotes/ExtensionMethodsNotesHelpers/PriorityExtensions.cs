namespace PlayersGuide.Notes.SubNotes.ExtensionMethodsNotesHelpers;

public static class PriorityExtensions
{
    public static bool RequiresImmediateAction(this Priority p)
    {
        return p is Priority.High or Priority.Critical;
    }

    public static string ToDisplayString(this Priority p) => p switch
    {
        Priority.Low => "Low priority",
        Priority.Medium => "Medium priority",
        Priority.High => "High - handle soon",
        Priority.Critical => "Critical - handle NOW",
        _ => p.ToString(),
    };
}
