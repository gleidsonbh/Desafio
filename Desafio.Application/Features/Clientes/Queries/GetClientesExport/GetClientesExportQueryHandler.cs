using AutoMapper;
using Desafio.Application.Contracts.Persistence;
using Desafio.Domain.Entities;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using MediatR;

namespace Desafio.Application.Features.Clientes.Queries.GetClientesExport
{
    public class GetClientesExportQueryHandler : IRequestHandler<GetClientesExportQuery, ClienteExportFileVm>
    {
        private readonly IAsyncRepository<Cliente> _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetClientesExportQueryHandler(IMapper mapper, IAsyncRepository<Cliente> clienteRespository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _clienteRepository = clienteRespository;
            _csvExporter = csvExporter;
        }

        public async Task<ClienteExportFileVm> Handle(GetClientesExportQuery request, CancellationToken cancellationToken)
        {
            var allClientes = _mapper.Map<List<ClienteExportDto>>((await _clienteRepository.ListAllAsync()).OrderBy(x => x.NomeCompleto));

            var fileData = _csvExporter.ExportClientesToCsv(allClientes);

            var clienteExportFileDto = new ClienteExportFileVm() { ContentType= "text/csv" , Data = fileData, ClienteExportFileName = $"{Guid.NewGuid()}.csv" };

            return clienteExportFileDto;
        }
    }
}
