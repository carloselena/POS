using POS.Core.Application.Interfaces.Repositories;
using POS.Core.Domain.Entities;
using POS.Infrastructure.Persistence.Contexts;

namespace POS.Infrastructure.Persistence.Repositories
{
    public class MeasurementUnitRepository : GenericRepository<MeasurementUnit>, IMeasurementUnitRepository
    {
        public MeasurementUnitRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            
        }
    }
}
