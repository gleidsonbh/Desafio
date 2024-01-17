using Desafio.Application.Features.Clientes.Queries.GetClienteList;
using MediatR;

namespace Desafio.Application.Features.Clientes.Queries.GetClienteByDDDNumero
{
    public class GetClienteByDDDNumeroQuery : IRequest<ClienteListVm>
    {
        public int DDD {  get; set; }
        public int Numero { get; set; }
    }
}
