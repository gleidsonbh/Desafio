using Desafio.Application.Contracts.Persistence;
using Desafio.Domain.Entities;

namespace Desafio.Persistence.Respositories
{
    public class TelefoneRepository : BaseRepository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(DesafioDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsDDDNumeroUnicoPorCliente(int DDD, int Numero, Guid ClienteId)
        {
            var matches = _dbContext.Telefones.Any(t => t.DDD.Equals(DDD) &&  t.Numero.Equals(Numero) && t.ClienteId.Equals(ClienteId));
            return Task.FromResult(matches);
        }
    }
}
