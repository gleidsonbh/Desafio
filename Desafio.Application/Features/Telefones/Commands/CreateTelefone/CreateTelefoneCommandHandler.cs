using AutoMapper;
using Desafio.Application.Contracts.Persistence;
using Desafio.Domain.Entities;
using MediatR;

namespace Desafio.Application.Features.Telefones.Commands.CreateTelefone
{
    public class CreateTelefoneCommandHandler : IRequestHandler<CreateTelefoneCommand, CreateTelefoneCommandResponse>
    {
        private readonly ITelefoneRepository _telefoneRespository;
        private readonly IMapper _mapper;

        public CreateTelefoneCommandHandler(IMapper mapper, ITelefoneRepository telefoneRespository)
        {
            _mapper = mapper;
            _telefoneRespository = telefoneRespository;
        }

        public async Task<CreateTelefoneCommandResponse> Handle(CreateTelefoneCommand request, CancellationToken token)
        {
            var createTelefoneCommandResponse = new CreateTelefoneCommandResponse();

            var validator = new CreateTelefoneCommandValidator(_telefoneRespository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createTelefoneCommandResponse.Success = false;
                createTelefoneCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createTelefoneCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createTelefoneCommandResponse.Success)
            {
                var telefone = new Telefone()
                {
                    DDD = request.DDD,
                    Numero = request.Numero,
                    ClienteId = request.ClienteId
                };
                telefone = await _telefoneRespository.AddAsync(telefone);
                createTelefoneCommandResponse.Telefone = _mapper.Map<CreateTelefoneDto>(telefone);
            }

            return createTelefoneCommandResponse;
        }
    }
}
