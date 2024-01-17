using Desafio.Domain.Entities;
using MediatR;

namespace Desafio.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
