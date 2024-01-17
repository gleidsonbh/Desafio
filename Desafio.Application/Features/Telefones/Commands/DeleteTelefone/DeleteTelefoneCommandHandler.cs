using AutoMapper;
using Desafio.Application.Contracts.Persistence;
using Desafio.Application.Exceptions;
using Desafio.Domain.Entities;
using MediatR;

namespace Desafio.Application.Features.Telefones.Commands.DeleteTelefone
{
    public class DeleteTelefoneCommandHandler : IRequestHandler<DeleteTelefoneCommand, Unit>
    {
        private IAsyncRepository<Telefone> _telefoneRepository;
        private readonly IMapper _mapper;

        public DeleteTelefoneCommandHandler(IMapper mapper, IAsyncRepository<Telefone> telefoneRepository)
        {
            _mapper = mapper;
            _telefoneRepository = telefoneRepository;
        }

        public async Task<Unit> Handle(DeleteTelefoneCommand request, CancellationToken cancellationToken)
        {
            var telefoneToDelete = await _telefoneRepository.GetByIdAsync(request.Id);

            if (telefoneToDelete == null)
            {
                throw new NotFoundException(nameof(Telefone), request.Id);
            }

            await _telefoneRepository.DeleteAsync(telefoneToDelete);

            return Unit.Value;
        }
    }
}
