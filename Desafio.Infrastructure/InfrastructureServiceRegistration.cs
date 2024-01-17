using Desafio.Infrastructure.FileExport;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<ICsvExporter, CsvExporter>();
            return services;
        }
    }
}
