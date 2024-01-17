using Desafio.Api.Utility;
using Desafio.Application.Features.Clientes.Commands.CreateCliente;
using Desafio.Application.Features.Clientes.Commands.DeleteCliente;
using Desafio.Application.Features.Clientes.Commands.UpdateCliente;
using Desafio.Application.Features.Clientes.Queries.GetClienteByDDDNumero;
using Desafio.Application.Features.Clientes.Queries.GetClienteList;
using Desafio.Application.Features.Clientes.Queries.GetClientesExport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region [GET]

        [HttpGet("all", Name ="GetAllClientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ClienteListVm>>> GetAllClientes()
        {
            var dtos = await _mediator.Send(new GetClientesListQuery());
            return Ok(dtos);
        }

        [HttpGet("{DDD}/{Numero}", Name = "GetClienteByDDDNumero")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ClienteListVm>>> GetClienteByDDDNumero(int DDD, int Numero)
        {
            var dtos = await _mediator.Send(new GetClienteByDDDNumeroQuery() { DDD = DDD, Numero = Numero});
            return Ok(dtos);
        }

        #endregion

        [HttpPost(Name = "AddCliente")]
        public async Task<ActionResult<CreateClienteCommandResponse>> Create([FromBody] CreateClienteCommand createClienteCommand)
        {
            var response = await _mediator.Send(createClienteCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateClienteCommand updateClienteCommand)
        {
            await _mediator.Send(updateClienteCommand);
            return NoContent();
        }

        [HttpDelete("{email}", Name = "DeleteCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string email)
        {
            var deleteClienteCommand = new DeleteClienteCommand() { Email = email };
            await _mediator.Send(deleteClienteCommand);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportClientes")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportClientes()
        {
            var fileDto = await _mediator.Send(new GetClientesExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.ClienteExportFileName);
        }

    }
}
