using Desafio.Application.Contracts.Persistence;
using FluentValidation;

namespace Desafio.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateClienteCommandValidator(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;

            RuleFor(p => p.NomeCompleto)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .NotNull()
                .MaximumLength(120).WithMessage("{PropertyName} deve ter no máximo 120 caracteres.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .NotNull()
                .MaximumLength(120).WithMessage("{PropertyName} deve ter no máximo 120 caracteres.");

            RuleFor(c => c)
                .MustAsync(ClienteEmailUnico)
                .WithMessage("Já existe cliente cadastrado com este e-mail");
        }

        private async Task<bool> ClienteEmailUnico(CreateClienteCommand e, CancellationToken token)
        {
            return !(await _clienteRepository.IsClienteEmailUnico(e.Email));
        }
    }
}
