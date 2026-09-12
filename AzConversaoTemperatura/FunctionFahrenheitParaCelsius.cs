using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Net;

namespace ConversaoTemperatura;

public class FunctionFahrenheitParaCelsius
{
    private readonly ILogger<FunctionFahrenheitParaCelsius> _logger;

    public FunctionFahrenheitParaCelsius(ILogger<FunctionFahrenheitParaCelsius> logger)
    {
        _logger = logger;
    }

    [Function("ConverterFahrenheitParaCelsius")]
    [OpenApiOperation(operationId: "ConverterParaCelsius", tags: new[] { "Conversao" })]
    [OpenApiParameter(name: "fahrenheit", In = ParameterLocation.Path, Required = true, Type = typeof(double), Description = "Valor em Fahrenheit.")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "Mensagem de resposta.")]

    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ConverterFahrenheitParaCelsius/{fahrenheit}")] HttpRequest req, double fahrenheit)
    {
        _logger.LogInformation($"Parâmetro recebido: {fahrenheit}", fahrenheit);
        
        var valorEmCelsius = (fahrenheit - 32) * 5 / 9;

        string requestBody = $"O valor em Fahrenheit é {fahrenheit} e convertido para Celsius é {valorEmCelsius}.";

        _logger.LogInformation($"Parâmetro recebido: {fahrenheit}", fahrenheit);
        _logger.LogInformation($"Conversão efetuada. Resultado: {valorEmCelsius}");
        return new OkObjectResult(requestBody);
    }
}