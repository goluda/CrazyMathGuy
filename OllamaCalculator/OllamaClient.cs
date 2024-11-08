using System.Net.Http.Json;

namespace OllamaCalculator;

public class OllamaClient(HttpClient httpClient)
{
    public async Task<string> AskOllama(string prompt, string system)
    {
        var request = new OllamaRequest
        {
            Model = "llama3.2",
            System = system,
            Prompt = prompt
        };
        var response = await httpClient.PostAsJsonAsync("http://localhost:11434/api/generate", request);
        var responseObject = await response.Content.ReadFromJsonAsync<OllamaResponse>();
        return responseObject?.Response ?? string.Empty;
    }
}
