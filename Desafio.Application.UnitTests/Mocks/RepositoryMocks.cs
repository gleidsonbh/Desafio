using Desafio.Application.Contracts.Persistence;
using Desafio.Domain.Entities;
using Moq;

namespace Desafio.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IClienteRepository> GetClienteRepository()
        {
            var cliente1Guid = Guid.NewGuid();
            var cliente2Guid = Guid.NewGuid();
            var cliente3Guid = Guid.NewGuid();
            var cliente4Guid = Guid.NewGuid();

            var clientes = new List<Cliente>
            {
                new Cliente
                {
                    Id = cliente1Guid,
                    NomeCompleto = "João da Silva",
                    Email = "joao@joao.com.br"
                },
                new Cliente
                {
                    Id = cliente2Guid,
                    NomeCompleto = "Maria da Silva",
                    Email = "maria@maria.com.br"
                },
                new Cliente
                {
                    Id= cliente3Guid,
                    NomeCompleto = "José da Silva",
                    Email = "jose@jose.com.br",
                    Telefones = new List<Telefone>
                    {
                        new Telefone
                        {
                            Id = Guid.NewGuid(),
                            DDD = 11,
                            Numero = 999009900,
                            ClienteId = cliente3Guid,
                            Tipo = TipoTelefone.Celular
                        }
                    }
                },
                new Cliente
                {
                    Id = cliente4Guid,
                    NomeCompleto = "Ana da Silva",
                    Email = "ana@ana.com.br"
                }
            };

            var mockClienteRepository = new Mock<IClienteRepository>();
            mockClienteRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(clientes);

            mockClienteRepository.Setup(repo => repo.AddAsync(It.IsAny<Cliente>())).ReturnsAsync(
                (Cliente cliente) =>
                {
                    clientes.Add(cliente);
                    return cliente;
                });

            return mockClienteRepository;
        }
    }
}
