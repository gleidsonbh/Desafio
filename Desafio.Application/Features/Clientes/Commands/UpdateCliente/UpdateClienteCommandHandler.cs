using AutoMapper;
using Desafio.Application.Contracts.Persistence;
using Desafio.Application.Exceptions;
using Desafio.Domain.Entities;
using MediatR;

namespace Desafio.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Unit>
    {
        private readonly IAsyncRepository<Cliente> _clienteRepository;
        private readonly IMapper _mapper;

        public UpdateClienteCommandHandler(IMapper mapper, IAsyncRepository<Cliente> clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteToUpdate = await _clienteRepository.GetByIdAsync(request.Id);
            if (clienteToUpdate == null)
            {
                throw new NotFoundException(nameof(Cliente), request.Id);
            }

            var validator = new UpdateClienteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request, clienteToUpdate, typeof(UpdateClienteCommand), typeof(Cliente));

            await _clienteRepository.UpdateAsync(clienteToUpdate);

            return Unit.Value;
        }
    }
}
