using System.Text.Json.Serialization;

namespace OllamaCalculator;

public class OllamaResponse
{
    [JsonPropertyName("response")]
    public string Response { get; set; } = string.Empty;
}
