using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace POS.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
        }
    }
}
