using AutoMapper;
using Desafio.Application.Contracts.Persistence;
using Desafio.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Desafio.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, CreateClienteCommandResponse>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateClienteCommandHandler> _logger;

        public CreateClienteCommandHandler(IMapper mapper,
                                           IClienteRepository clienteRepository,
                                           ILogger<CreateClienteCommandHandler> logger)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _logger = logger;
        }

        public async Task<CreateClienteCommandResponse> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var createClienteCommandResponse = new CreateClienteCommandResponse();

            var validator = new CreateClienteCommandValidator(_clienteRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createClienteCommandResponse.Success = false;
                createClienteCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createClienteCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createClienteCommandResponse.Success)
            {

                List<Telefone> listaTelefones = new();

                foreach (var item in request.Telefones)
                {
                    listaTelefones.Add(new Telefone
                    {
                        DDD = item.DDD,
                        Numero = item.Numero,
                        Id = Guid.NewGuid()
                    });
                }

                var cliente = new Cliente()
                {
                    NomeCompleto = request.NomeCompleto,
                    Email = request.Email,
                    Telefones = listaTelefones,
                };
                cliente = await _clienteRepository.AddAsync(cliente);
                createClienteCommandResponse.Cliente = _mapper.Map<CreateClienteDto>(cliente);
            }

            return createClienteCommandResponse;
        }
    }
}
