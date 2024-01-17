using Desafio.Domain.Common;
using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Persistence
{
    public class DesafioDbContext : DbContext
    {
        public DesafioDbContext(DbContextOptions<DesafioDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Auditoria>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DataCriacao = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.DataAlteracao = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
