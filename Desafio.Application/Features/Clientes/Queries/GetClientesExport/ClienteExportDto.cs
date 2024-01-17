using Desafio.Domain.Entities;

namespace Desafio.Application.Features.Clientes.Queries.GetClientesExport
{
    public class ClienteExportDto
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Telefone>? Telefones { get; set; }
    }
}
