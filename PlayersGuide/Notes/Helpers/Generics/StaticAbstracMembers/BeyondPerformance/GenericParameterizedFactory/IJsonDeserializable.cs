namespace PlayersGuide.Notes.Helpers.Generics.StaticAbstracMembers.BeyondPerformance.GenericParameterizedFactory;

public interface IJsonDeserializable<T>
{
    static abstract T FromJson(string json);
}
