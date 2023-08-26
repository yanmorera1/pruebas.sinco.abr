using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinco.Prueba.Colegio.Application.Contracts.Persistence;
using Sinco.Prueba.Colegio.Infrastructure.Persistence;
using Sinco.Prueba.Colegio.Infrastructure.Repositories;

namespace Sinco.Prueba.Colegio.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection RegisterInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //DbContext
            services.AddDbContext<ColegioDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            //Generic repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
