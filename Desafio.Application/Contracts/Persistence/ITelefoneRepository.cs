using Desafio.Domain.Entities;

namespace Desafio.Application.Contracts.Persistence
{
    public interface ITelefoneRepository : IAsyncRepository<Telefone>
    {
        Task<bool> IsDDDNumeroUnicoPorCliente(int DDD, int Numero, Guid ClienteId);
    }
}
