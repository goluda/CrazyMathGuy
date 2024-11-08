using System.Text.Json.Serialization;

namespace OllamaCalculator;

public class CalculatorResponse
{
    [JsonPropertyName("result")]
    public decimal? Result { get; set; }
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}