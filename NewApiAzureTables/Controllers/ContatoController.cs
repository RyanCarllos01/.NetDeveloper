using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using NewApiAzureTables.Models;
namespace NewApiAzureTables.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        // obtendo a configuração e criando a model
        private readonly string _connectionString;
        private readonly string _tableName;
        public ContatoController(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("SAConnectionString");
            _tableName = configuration.GetValue<string>("AzureTableName");
        }

        // criando método inserir
        private TableClient GetTableClient()
        {
            var serviceClient = new TableServiceClient(_connectionString);
            var tableClient = serviceClient.GetTableClient(_tableName);

            tableClient.CreateIfNotExists();
            return tableClient;
        }

        [HttpPost]
        public IActionResult Criar(ContatoInput input)
        {
            var tableClient = GetTableClient();

            var contato = new Contato
            {
                Nome = input.Nome,
                Telefone = input.Telefone,
                Email = input.Email,
                RowKey = Guid.NewGuid().ToString(),
            };
            contato.PartitionKey = contato.RowKey;

            // upsertEntity é o método que insere ou atualiza o registro
            tableClient.UpsertEntity(contato);
            return Ok(contato);
        }
        // método atualizar
        [HttpPut("{id}")]
        public IActionResult Atualizar(string id, ContatoInput input)
        {
            var tableClient = GetTableClient();

            // obtendo o registro pelo id
            var contato = tableClient.GetEntity<Contato>(id, id).Value;

            // atualizando os campos
            contato.Nome = input.Nome;
            contato.Telefone = input.Telefone;
            contato.Email = input.Email;

            // upsertEntity é o método que insere ou atualiza o registro
            tableClient.UpsertEntity(contato);
            return Ok();
        }
        // Criando método de listagem
        [HttpGet("Listar")]
        public IActionResult ObterTodos()
        {
            var tableClient = GetTableClient();

            // obtendo todos os registros da tabela
            var contatos = tableClient.Query<Contato>().ToList();

            return Ok(contatos);
        }

        // Criando método de obter por nome
        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult ObterPorNome(string nome)
        {
            var tableClient = GetTableClient();

            // obtendo todos os registros da tabela
            var contatos = tableClient.Query<Contato>(x => x.Nome == nome).ToList();

            return Ok(contatos);
        }
        // criando o método de deletar
        [HttpDelete("{id}")]
        public IActionResult Deletar(string id)
        {
            var tableClient = GetTableClient();

            // deletando o registro pelo id
            tableClient.DeleteEntity(id, id);

            return NoContent();
        }
    }
}
