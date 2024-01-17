using Desafio.Application.Responses;

namespace Desafio.Application.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandResponse : BaseResponse
    {
        public CreateClienteCommandResponse() : base() { }

        public CreateClienteDto Cliente { get; set; } = default!;
        
    }
}
