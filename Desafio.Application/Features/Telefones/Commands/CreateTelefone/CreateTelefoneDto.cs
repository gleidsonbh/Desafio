using Desafio.Domain.Entities;

namespace Desafio.Application.Features.Telefones.Commands.CreateTelefone
{
    public class CreateTelefoneDto
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
    }
}
