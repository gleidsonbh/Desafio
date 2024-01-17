using MediatR;

namespace Desafio.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommand : IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
