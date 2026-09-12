using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
namespace NewApiAzureTables.Models
{
    public class Contato : ITableEntity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
       
        // precisa ter essas propriedades abaixo para sincronizar com o Azure Tables       
        // nome da partição
        public string PartitionKey { get; set; }
        // chave do registro
        public string RowKey { get; set; }
        //Timestamp é a data que o registro foi salvo
        public DateTimeOffset? Timestamp { get; set; }
        // Etag é o header do http
        public ETag ETag { get; set; }
    }
}