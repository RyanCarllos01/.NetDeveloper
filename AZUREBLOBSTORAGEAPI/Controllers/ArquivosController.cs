using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
namespace AZUREBLOBSTORAGEAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArquivosController : ControllerBase
    {
        // recebendo as chaves do azure blob storage
        private readonly string _connectionString;
        private readonly string _containerName;

        public ArquivosController(IConfiguration configuration)
        {
            // pegando as chaves do appsettings.json
            _connectionString = configuration.GetValue<string>("BlobConnectionString");
            _containerName = configuration.GetValue<string>("BlobContainerName");
        }

        [HttpPost("Upload")]
        public IActionResult UploadArquivo(IFormFile arquivo)
        {
            BlobContainerClient container = new(_connectionString, _containerName);
            BlobClient blob = container.GetBlobClient(arquivo.FileName);

            using var data = arquivo.OpenReadStream();
            blob.Upload(data, new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType = arquivo.ContentType
                }
            });
            // pra retornar a url do arquivo que foi enviado para o blob storage
            return Ok(blob.Uri.ToString());
        }
        // criando e testando o método de download do arquivo
        [HttpGet("Download/{nomearquivo}")]
        public IActionResult DownloadArquivo(string nomearquivo)
        {
            BlobContainerClient container = new(_connectionString, _containerName);
            BlobClient blob = container.GetBlobClient(nomearquivo);

            // fazendo validação se o arquivo existe no blob storage
            if (!blob.Exists())
                return BadRequest();
            var retorno = blob.DownloadContent();
            return File(retorno.Value.Content.ToArray(), retorno.Value.Details.ContentType, blob.Name);
        }
        // criando e testando o método de deletar o arquivo 
        [HttpDelete("Apagar/{nomearquivo}")]
        public IActionResult DeletarArquivo(string nomearquivo)
        {
            BlobContainerClient container = new(_connectionString, _containerName);
            BlobClient blob = container.GetBlobClient(nomearquivo);

            blob.DeleteIfExists();
            return NoContent();

        }
        // Criando e testando o método de listar arquivos
        [HttpGet("Listar")]
        public IActionResult ListarArquivos()
        {
            List<BlobDto> blobsDto = new List<BlobDto>();
            BlobContainerClient container = new(_connectionString, _containerName);
            foreach (var blob in container.GetBlobs())
            {
                blobsDto.Add(new BlobDto
                {
                    Nome = blob.Name,
                    Tipo = blob.Properties.ContentType,
                    Uri = container.Uri.AbsoluteUri + "/" + blob.Name
                });
            }
            return Ok(blobsDto);
        }
        }
    }
