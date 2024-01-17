using MediatR;

namespace Desafio.Application.Features.Telefones.Commands.DeleteTelefone
{
    public class DeleteTelefoneCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
