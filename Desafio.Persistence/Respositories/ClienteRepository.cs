using Desafio.Application.Contracts.Persistence;
using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Persistence.Respositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {

        public ClienteRepository(DesafioDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Cliente> GetClienteByEmailAsync(string email)
        {
            var cliente = await _dbContext.Clientes.Where(x => x.Email.Equals(email)).Include(x => x.Telefones).FirstOrDefaultAsync();
            return cliente;
        }

        public async Task<List<Cliente>> GetClientesComTelefones()
        {
            var allClientes = await _dbContext.Clientes.Include(x => x.Telefones).ToListAsync();
            return allClientes;
        }

        public Task<bool> IsClienteEmailUnico(string email)
        {
            var matches = _dbContext.Clientes.Any(e => e.Email.Equals(email));
            return Task.FromResult(matches);
        }

        public async Task<Cliente> GetClienteByDDDNumeroAsync(int DDD, int Numero)
        {
            //var cliente = await (from c in _dbContext.Clientes
            //                     join t in _dbContext.Telefones.Where(x => x.DDD.Equals(DDD) && x.Numero.Equals(Numero)) on c.Id equals t.ClienteId
            //                     select new { c = c, t = t }).FirstOrDefaultAsync();

            var cliente = await _dbContext.Clientes.Where(
                                c => c.Telefones.First().DDD.Equals(DDD) && c.Telefones.First().Numero.Equals(Numero) && c.Id == c.Telefones.First().ClienteId)
                                .Include(x => x.Telefones).FirstOrDefaultAsync();

            return cliente;

        }
    }
}
