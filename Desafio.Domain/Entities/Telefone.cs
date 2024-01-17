using Desafio.Domain.Common;

namespace Desafio.Domain.Entities
{
    public class Telefone : Auditoria
    {
        public Guid Id { get; set; }

        public int DDD { get; set; }
        public int Numero { get; set; }
        public TipoTelefone Tipo { get; set; }

        public Guid ClienteId {  get; set; }

        public Cliente Cliente { get; set; } = default;
    }
}
