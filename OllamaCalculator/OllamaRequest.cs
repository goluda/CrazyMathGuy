namespace OllamaCalculator;

public class OllamaRequest
{
    public string Model { get; set; } = string.Empty;
    public string System { get; set; } = string.Empty;
    public string Prompt { get; set; } = string.Empty;
    public string Format { get; set; } = "json";
    public bool Stream { get; set; } = false;
}
