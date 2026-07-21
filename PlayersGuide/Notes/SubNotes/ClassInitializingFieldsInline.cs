using PlayersGuide.Notes.SubNotes.ClassInitializingFieldsInlineHelpers;

namespace PlayersGuide.Notes.SubNotes;

public static class ClassInitializingFieldsInline
{
    public static void Show()
    {
        // Check Score class in Helpers folder

        var tetrisScore = new Score();

        // The field assignments happen after the memory is zeroed out but before any constructor code runs.
        // These then become the default values for these fields.
        // Any constructor can override these defaults as needed.
    }
}
