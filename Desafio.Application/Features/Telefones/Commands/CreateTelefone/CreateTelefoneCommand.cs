using Desafio.Domain.Entities;
using MediatR;

namespace Desafio.Application.Features.Telefones.Commands.CreateTelefone
{
    public class CreateTelefoneCommand : IRequest<CreateTelefoneCommandResponse>
    {
        public Guid ClienteId { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
    }
}
