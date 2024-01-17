using Desafio.Application.Features.Clientes.Queries.GetClientesExport;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportClientesToCsv(List<ClienteExportDto> clienteExportDtos);
    }
}
