using System.Text.Json;

namespace PlayersGuide.Notes.SubNotes.GenericsHelpers.StaticAbstracMembers.BeyondPerformance.GenericParameterizedFactory;

public class Enemy : IJsonDeserializable<Enemy>
{
    public required string Name { get; set; }

    public static Enemy FromJson(string json)
    {
        return JsonSerializer.Deserialize<Enemy>(json) ?? throw new JsonException("Failed to deserialize Enemy");
    }
}
