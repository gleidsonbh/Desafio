using CsvHelper;
using Desafio.Application.Features.Clientes.Queries.GetClientesExport;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;

namespace Desafio.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportClientesToCsv(List<ClienteExportDto> clienteExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(clienteExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
