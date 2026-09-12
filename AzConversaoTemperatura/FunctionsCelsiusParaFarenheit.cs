using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Net;

namespace ConversaoTemperatura;

public class FunctionCelsiusParaFahrenheit
{
    private readonly ILogger<FunctionCelsiusParaFahrenheit> _logger;

    public FunctionCelsiusParaFahrenheit(ILogger<FunctionCelsiusParaFahrenheit> logger)
    {
        _logger = logger;
    }

    [Function("ConverterCelsiusParaFahrenheit")]
    [OpenApiOperation(operationId: "ConverterParaFahrenheit", tags: new[] { "Conversao" })]
    [OpenApiParameter(name: "celsius", In = ParameterLocation.Path, Required = true, Type = typeof(double), Description = "Valor em **Celsius** para Fahrenheit.")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "Retorna em farenheit")]

    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ConverterCelsiusParaFahrenheit/{celsius}")] HttpRequest req, double celsius)
    {
        _logger.LogInformation($"Parâmetro recebido: {celsius}", celsius);
        
        var valorEmFahrenheit = (celsius * 9 / 5) + 32;

        string requestBody = $"O valor em Celsius é {celsius} e convertido para Fahrenheit é {valorEmFahrenheit}.";

        _logger.LogInformation($"Conversão efetuada. Resultado: {valorEmFahrenheit}");
        return new OkObjectResult(requestBody);
    }
}