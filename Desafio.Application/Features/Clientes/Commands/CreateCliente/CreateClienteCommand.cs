using Desafio.Domain.Entities;
using MediatR;
using System.Diagnostics;
using System.Xml.Linq;

namespace Desafio.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommand : IRequest<CreateClienteCommandResponse>
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<CreateClienteTelefoneDto>? Telefones { get; set; }

        public override string ToString()
        {
            return $"Cliente nome: {NomeCompleto}; Email: {Email};";
        }
    }
}
