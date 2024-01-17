using AutoMapper;
using Desafio.Application.Contracts.Persistence;
using Desafio.Application.Features.Clientes.Commands.CreateCliente;
using Desafio.Application.Profiles;
using Desafio.Application.UnitTests.Mocks;
using Desafio.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace Desafio.Application.UnitTests.Clientes.Commands
{
    public class CreateClienteTests
    {
        private readonly IMapper _mapper;        
        private readonly Mock<IClienteRepository> _mockClienteRepository;
        private readonly ILogger<CreateClienteCommandHandler> _logger;

        public CreateClienteTests()
        {
            _mockClienteRepository = RepositoryMocks.GetClienteRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCliente_AddedToClientesRepo()
        {
            var handler = new CreateClienteCommandHandler(_mapper, _mockClienteRepository.Object, _logger);

            await handler.Handle(new CreateClienteCommand()
            {
                NomeCompleto = "Teste 123",
                Email = "teste@teste",
                //Telefones = new List<Telefone> { new Telefone { DDD = 31, Numero = 999009900, Tipo = TipoTelefone.Celular } }
            }, CancellationToken.None);

            var allClientes = await _mockClienteRepository.Object.ListAllAsync();
            allClientes.Count.ShouldBe(5);
        }
    }
}
