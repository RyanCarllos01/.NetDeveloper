namespace NewApiAzureTables.Models
{
    // DTO usado apenas para receber os dados do cliente via POST.
    // Não inclui PartitionKey/RowKey/Timestamp/ETag porque esses campos
    // são controlados pelo Azure Table Storage / pelo próprio controller,
    // e não devem ser preenchidos pelo cliente.
    public class ContatoInput
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
