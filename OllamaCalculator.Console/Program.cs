// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using OllamaCalculator;

Console.WriteLine("HI, i'm math calculator, nice to see you!");
var expression = "";
var httpClient = new HttpClient();
var options = new JsonSerializerOptions();
var ollamaClient = new OllamaClient(httpClient,options);
var calculator = new MathClient(ollamaClient,options);

while (true)
{
    Console.WriteLine("Please enter your expression:");
    expression = Console.ReadLine();
    if (expression == "")
    {
        break;
    }
    var result = await calculator.DoCalculationFunny(expression!);
    Console.WriteLine($"Result: {result.Result}, \n{result.Message}");
}
