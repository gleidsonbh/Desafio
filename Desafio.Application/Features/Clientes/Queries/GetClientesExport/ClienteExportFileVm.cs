namespace Desafio.Application.Features.Clientes.Queries.GetClientesExport
{
    public class ClienteExportFileVm
    {
        public string ClienteExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}
