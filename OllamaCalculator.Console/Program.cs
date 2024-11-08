// See https://aka.ms/new-console-template for more information
using OllamaCalculator;

Console.WriteLine("HI, i'm math calculator, nice to see you!");
var expression = "";
var httpClient = new HttpClient();
var ollamaClient = new OllamaClient(httpClient);
var calculator = new MathClient(ollamaClient);

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
