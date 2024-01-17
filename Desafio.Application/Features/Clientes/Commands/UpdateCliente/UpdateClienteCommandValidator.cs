using Desafio.Application.Contracts.Persistence;
using Desafio.Application.Features.Clientes.Commands.CreateCliente;
using FluentValidation;

namespace Desafio.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        public UpdateClienteCommandValidator() 
        {
            RuleFor(p => p.NomeCompleto)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .NotNull()
                .MaximumLength(120).WithMessage("{PropertyName} deve ter no máximo 120 caracteres.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
                .NotNull()
                .MaximumLength(120).WithMessage("{PropertyName} deve ter no máximo 120 caracteres.");

            //RuleFor(c => c)
            //    .MustAsync(ClienteEmailUnico)
            //    .WithMessage("Já existe cliente cadastrado com este e-mail");
        }

        //private async Task<bool> ClienteEmailUnico(CreateClienteCommand e, CancellationToken token)
        //{
        //    return !(await _clienteRepository.IsClienteEmailUnico(e.Email));
        //}
    }
}
