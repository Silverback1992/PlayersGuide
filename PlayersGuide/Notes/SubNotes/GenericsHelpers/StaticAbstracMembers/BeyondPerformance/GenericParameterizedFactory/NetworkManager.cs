namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.StaticAbstracMembers.BeyondPerformance.GenericParameterizedFactory;

public class NetworkManager
{
    public T FetchAndBuild<T>(string url) where T : IJsonDeserializable<T>
    {
        string json = FetchJsonFromUrl(url);
        return T.FromJson(json);
    }

    private string FetchJsonFromUrl(string url)
    {
        return "{ \"Name\": \"Goblin\" }";
    }
}
