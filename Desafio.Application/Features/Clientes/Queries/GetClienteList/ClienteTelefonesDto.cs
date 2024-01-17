using Desafio.Domain.Entities;

namespace Desafio.Application.Features.Clientes.Queries.GetClienteList
{
    public class ClienteTelefonesDto
    {
        public Guid Id { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
    }
}
