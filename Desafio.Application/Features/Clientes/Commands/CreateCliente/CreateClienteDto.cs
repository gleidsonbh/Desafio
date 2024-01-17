using Desafio.Domain.Entities;

namespace Desafio.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteDto
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<CreateClienteTelefoneDto>? Telefones { get; set; }
    }
}
