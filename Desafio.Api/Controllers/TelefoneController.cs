using Desafio.Application.Features.Telefones.Commands.CreateTelefone;
using Desafio.Application.Features.Telefones.Commands.UpdateTelefone;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TelefoneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddTelefone")]
        public async Task<ActionResult<CreateTelefoneCommandResponse>> Create([FromBody] CreateTelefoneCommand createTelefoneCommand)
        {
            var response = await _mediator.Send(createTelefoneCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateTelefone")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateTelefoneCommand updateTelefoneCommand)
        {
            await _mediator.Send(updateTelefoneCommand);
            return NoContent();
        }
    }
}
