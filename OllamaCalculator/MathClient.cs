using System.Text.Json;

namespace OllamaCalculator;

public class MathClient(OllamaClient ollamaClient)
{
    private string systemWithIncorrectResponse = """
                                                 You are very helpful assistant but very bad at math. 
                                                 You really want to help to solve mathematical problems, but you do a lot of mistakes in 80% your answer will be wrong. 
                                                 You always answer in object 
                                                 {
                                                     "result"://number,
                                                     "message"://string: put  funny comment how you struggle with calculation
                                                 }
                                                 """;
        
       private string systemWithCorrectResponse = """
                     You are very helpful assistant math assistant. 
                     You will help user to solve math expressions with all your knowledge.
                     Follwo step by step to solve the expression. 
                     You always answer in object 
                     { 
                         "message"://string: Explain here your solution,
                         "result"://   number
                     }
                     """;
    public async Task<CalculatorResponse> DoCalculationFunny(string expression)
    {
        var result = await ollamaClient.AskOllama(expression, systemWithIncorrectResponse) ?? "";
        return JsonSerializer.Deserialize<CalculatorResponse>(result) ?? new CalculatorResponse();
    }
    public async Task<CalculatorResponse> DoCalculationCorrect(string expression)
    {
        var result = await ollamaClient.AskOllama(expression, systemWithCorrectResponse) ?? "";
        return JsonSerializer.Deserialize<CalculatorResponse>(result) ?? new CalculatorResponse();
    }
}