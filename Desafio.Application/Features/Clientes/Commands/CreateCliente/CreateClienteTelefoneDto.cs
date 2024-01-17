using Desafio.Domain.Entities;

namespace Desafio.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteTelefoneDto
    {
        public int DDD { get; set; }
        public int Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
    }
}
