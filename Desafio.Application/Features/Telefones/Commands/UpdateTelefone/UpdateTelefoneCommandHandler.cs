using AutoMapper;
using Desafio.Application.Contracts.Persistence;
using Desafio.Application.Exceptions;
using Desafio.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Desafio.Application.Features.Telefones.Commands.UpdateTelefone
{
    public class UpdateTelefoneCommandHandler : IRequestHandler<UpdateTelefoneCommand, Unit>
    {
        private readonly IAsyncRepository<Telefone> _telefoneRepository;
        private readonly IMapper _mapper;

        public UpdateTelefoneCommandHandler(IMapper mapper, IAsyncRepository<Telefone> telefoneRepository)
        {
            _mapper = mapper;
            _telefoneRepository = telefoneRepository;
        }

        public async Task<Unit> Handle(UpdateTelefoneCommand request, CancellationToken cancellationToken)
        {

            var telefoneToUpdate = await _telefoneRepository.GetByIdAsync(request.Id);
            if (telefoneToUpdate == null)
            {
                throw new NotFoundException(nameof(Telefone), request.Id);
            }

            var validator = new UpdateTelefoneCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, telefoneToUpdate, typeof(UpdateTelefoneCommand), typeof(Telefone));

            await _telefoneRepository.UpdateAsync(telefoneToUpdate);

            return Unit.Value;
        }
    }
}
