using AutoMapper;
using Desafio.Application.Contracts.Persistence;
using Desafio.Application.Features.Clientes.Queries.GetClienteList;
using MediatR;

namespace Desafio.Application.Features.Clientes.Queries.GetClienteByDDDNumero
{
    public class GetClienteByDDDNumeroQueryHandler : IRequestHandler<GetClienteByDDDNumeroQuery, ClienteListVm>
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public GetClienteByDDDNumeroQueryHandler(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteListVm> Handle(GetClienteByDDDNumeroQuery request, CancellationToken cancellationToken)
        {
            var list = await _clienteRepository.GetClienteByDDDNumeroAsync(request.DDD, request.Numero);
            return _mapper.Map<ClienteListVm>(list);
        }
    }
}
