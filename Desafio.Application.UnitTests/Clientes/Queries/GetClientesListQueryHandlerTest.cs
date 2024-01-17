using AutoMapper;
using Desafio.Application.Contracts.Persistence;
using Desafio.Application.Features.Clientes.Queries.GetClienteList;
using Desafio.Application.Profiles;
using Desafio.Application.UnitTests.Mocks;
using Desafio.Domain.Entities;
using Moq;
using Shouldly;

namespace Desafio.Application.UnitTests.Clientes.Queries
{
    public class GetClientesListQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IClienteRepository> _mockClienteRepository;

        public GetClientesListQueryHandlerTest()
        {
            _mockClienteRepository = RepositoryMocks.GetClienteRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetClientesListTest()
        {
            var handler = new GetClientesListQueryHandler(_mapper, _mockClienteRepository.Object);

            var result = await handler.Handle(new GetClientesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ClienteListVm>>();
            result.Count.ShouldBe(4);
        }
    }
}
