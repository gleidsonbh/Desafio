using FluentValidation;

namespace Desafio.Application.Features.Telefones.Commands.UpdateTelefone
{
    public class UpdateTelefoneCommandValidator : AbstractValidator<UpdateTelefoneCommand>
    {
        public UpdateTelefoneCommandValidator()
        {
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
    }
}
