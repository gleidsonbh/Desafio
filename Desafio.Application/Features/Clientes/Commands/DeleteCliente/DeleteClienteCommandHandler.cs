using AutoMapper;
using Desafio.Application.Contracts.Persistence;
using Desafio.Application.Exceptions;
using Desafio.Domain.Entities;
using MediatR;

namespace Desafio.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Unit>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public DeleteClienteCommandHandler(IMapper mapper, IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteDelete = await _clienteRepository.GetClienteByEmailAsync(request.Email); 
            if (clienteDelete == null)
            {
                throw new NotFoundException(nameof(Cliente), request.Email);
            }

            await _clienteRepository.DeleteAsync(clienteDelete);

            return Unit.Value;
        }
    }
}
