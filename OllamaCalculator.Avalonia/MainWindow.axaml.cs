using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace OllamaCalculator.Avalonia;

public partial class MainWindow : Window
{
    
    private readonly MathClient _calculator;
    public MainWindow()
    {
        var options = new JsonSerializerOptions();
        options.TypeInfoResolverChain.Add(OllamaRequestSerializationContext.Default);
        options.TypeInfoResolverChain.Add(OllamaResponseSerializationContext.Default);
        options.TypeInfoResolverChain.Add(CalculatorResponseSerializationContext.Default);
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.PropertyNameCaseInsensitive = false;
        
        
        _calculator = new MathClient(new OllamaClient(new HttpClient(),options),options);
        InitializeComponent();
    }

    private void CalculateMethod(object? sender, RoutedEventArgs e)
    {
        Result.Content = "";
        ResultMessage.Text = "";
        var expression = TextBoxExpression.Text;
        Calculate(expression);
    }
    private void CalculateMethodWithCorrectResponse(object? sender, RoutedEventArgs e)
    {
        Result.Content = "";
        ResultMessage.Text = "";
        var expression = TextBoxExpression.Text;
        CalculateWithCorrectResposne(expression);
    }

    async void Calculate(string expression)
    {
        try
        {
            var result = await _calculator.DoCalculationFunny(expression);
            Result.Content = result.Result;
            ResultMessage.Text = result.Message;
        }
        catch(Exception ex)
        {
            ResultMessage.Text = ex.Message;
        }

    }
    async void CalculateWithCorrectResposne(string expression)
    {
        try{
            
            var result = await _calculator.DoCalculationCorrect(expression);
            Result.Content = result.Result;
            ResultMessage.Text = result.Message;
        }
        catch(Exception ex)
        {
            ResultMessage.Text = ex.Message;
        }

    }
    
    [JsonSerializable(typeof(OllamaRequest))]
    internal partial class OllamaRequestSerializationContext:JsonSerializerContext{}
    [JsonSerializable(typeof(OllamaResponse))]
    internal partial class OllamaResponseSerializationContext:JsonSerializerContext{}
    [JsonSerializable(typeof(CalculatorResponse))]
    internal partial class CalculatorResponseSerializationContext:JsonSerializerContext{}
}