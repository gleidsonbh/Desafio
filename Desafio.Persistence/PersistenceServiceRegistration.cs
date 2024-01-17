using Desafio.Application.Contracts.Persistence;
using Desafio.Persistence.Respositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DesafioDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DesafioConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();

            return services;
        }
    }
}
