using MediatR;

namespace Desafio.Application.Features.Clientes.Queries.GetClientesExport
{
    public class GetClientesExportQuery : IRequest<ClienteExportFileVm>
    {
    }
}
