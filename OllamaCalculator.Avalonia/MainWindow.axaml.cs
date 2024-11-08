using System.Net.Http;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace OllamaCalculator.Avalonia;

public partial class MainWindow : Window
{
    
    private readonly MathClient _calculator;
    public MainWindow()
    {
        _calculator = new MathClient(new OllamaClient(new HttpClient()));
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
        var result = await _calculator.DoCalculationFunny(expression);
        Result.Content = result.Result;
        ResultMessage.Text = result.Message;

    }
    async void CalculateWithCorrectResposne(string expression)
    {
        var result = await _calculator.DoCalculationCorrect(expression);
        Result.Content = result.Result;
        ResultMessage.Text = result.Message;

    }
}