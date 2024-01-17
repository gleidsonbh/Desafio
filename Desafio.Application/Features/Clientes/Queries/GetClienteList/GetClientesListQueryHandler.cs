using AutoMapper;
using Desafio.Application.Contracts.Persistence;
using MediatR;

namespace Desafio.Application.Features.Clientes.Queries.GetClienteList
{
    public class GetClientesListQueryHandler : IRequestHandler<GetClientesListQuery, List<ClienteListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public GetClientesListQueryHandler(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteListVm>> Handle(GetClientesListQuery request, CancellationToken cancellationToken)
        {
            var list = await _clienteRepository.GetClientesComTelefones();
            return _mapper.Map<List<ClienteListVm>>(list);
        }
    }
}
