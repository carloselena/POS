using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Core.Application.Interfaces.Persistence;
using POS.Core.Application.Interfaces.Repositories;
using POS.Infrastructure.Persistence.Contexts;
using POS.Infrastructure.Persistence.Repositories;
using POS.Infrastructure.Persistence.UnitOfWork;

namespace POS.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                                                        options.UseSqlServer(connectionString,
                                                        m => m.MigrationsAssembly(typeof(ApplicationDbContext)
                                                        .Assembly.FullName)));

            #region Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();
            services.AddScoped<IMeasurementUnitRepository, MeasurementUnitRepository>();
            #endregion
        }
    }
}
