using System.Net.Http.Json;
using System.Text.Json;

namespace OllamaCalculator;

public class OllamaClient(HttpClient httpClient,JsonSerializerOptions options)
{
    public async Task<string> AskOllama(string prompt, string system)
    {
        var request = new OllamaRequest
        {
            Model = "llama3.2",
            System = system,
            Prompt = prompt
        };
        
        var response = await httpClient.PostAsJsonAsync("http://localhost:11434/api/generate", request, options);
        var responseObject = await response.Content.ReadFromJsonAsync<OllamaResponse>(options);
        return responseObject?.Response ?? string.Empty;
    }
}
