using Desafio.Application.Responses;

namespace Desafio.Application.Features.Telefones.Commands.CreateTelefone
{
    public class CreateTelefoneCommandResponse : BaseResponse
    {
        public CreateTelefoneCommandResponse() : base() { }

        public CreateTelefoneDto Telefone { get; set; } = default!;
    }
}
