namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.StaticAbstracMembers.BeyondPerformance.GenericParameterizedFactory;

public interface IJsonDeserializable<T>
{
    static abstract T FromJson(string json);
}
