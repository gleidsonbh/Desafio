using Desafio.Domain.Common;

namespace Desafio.Domain.Entities
{
    public class Cliente : Auditoria
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Telefone>? Telefones { get; set; }
    }
}
