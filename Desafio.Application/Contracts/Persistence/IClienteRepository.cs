using Desafio.Domain.Entities;

namespace Desafio.Application.Contracts.Persistence
{
    public interface IClienteRepository : IAsyncRepository<Cliente>
    {
        Task<bool> IsClienteEmailUnico(string email);
        Task<List<Cliente>> GetClientesComTelefones();
        Task<Cliente> GetClienteByEmailAsync(string email);
        Task<Cliente> GetClienteByDDDNumeroAsync(int DDD, int Numero);
    }
}
