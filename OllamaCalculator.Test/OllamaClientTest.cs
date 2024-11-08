namespace OllamaCalculator.Test;

public class OllamaClientTest
{
    private HttpClient _client;
    [SetUp]
    public void Setup()
    {
        _client = new HttpClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
    }


    [Test]
    public async Task Test1()
    {
        var ollamaClient = new OllamaClient(_client);
        var result = await ollamaClient.AskOllama("How are you today?", "");
        Assert.NotNull(result);
    }

    [Test]
    public async Task Test2plu2_Returns_SomeResponse()
    {
        var mathClient = new MathClient(new OllamaClient(_client));
        var result = await mathClient.DoCalculationFunny("2+2");
        Assert.NotNull(result);
        Assert.NotNull(result.Result);
        Assert.NotNull(result.Message);
    }
}