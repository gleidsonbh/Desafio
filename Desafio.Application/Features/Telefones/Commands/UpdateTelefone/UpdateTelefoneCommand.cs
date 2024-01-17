using Desafio.Domain.Entities;
using MediatR;

namespace Desafio.Application.Features.Telefones.Commands.UpdateTelefone
{
    public class UpdateTelefoneCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int DDD { get; set; }
        public int Numero {  get; set; }
        public TipoTelefone Tipo { get; set; }
        public Guid ClienteId { get; set; }
    }
}
