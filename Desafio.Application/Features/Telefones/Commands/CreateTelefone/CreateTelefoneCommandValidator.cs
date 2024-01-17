using Desafio.Application.Contracts.Persistence;
using FluentValidation;

namespace Desafio.Application.Features.Telefones.Commands.CreateTelefone
{
    public class CreateTelefoneCommandValidator : AbstractValidator<CreateTelefoneCommand>
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public CreateTelefoneCommandValidator(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;

            RuleFor(p => p.DDD)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório")
                .NotNull()
                .GreaterThan(10).WithMessage("{PropertyName} inválido")
                .LessThan(100).WithMessage("{PropertyName} inválido");

            RuleFor(p => p.Numero)
                .NotEmpty().WithMessage("{PropertyName é obrigatório")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} é obrigatório");
        }

        private async Task<bool> DDDNumeroUnicoPorCliente(CreateTelefoneCommand e, CancellationToken token)
        {
            return !await _telefoneRepository.IsDDDNumeroUnicoPorCliente(e.DDD, e.Numero, e.ClienteId);
        }
    }
}
