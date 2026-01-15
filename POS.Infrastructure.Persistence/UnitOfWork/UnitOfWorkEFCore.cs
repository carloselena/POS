using POS.Core.Application.Interfaces.Persistence;
using POS.Infrastructure.Persistence.Contexts;

namespace POS.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWorkEFCore : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWorkEFCore(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task RollbackAsync()
        {
            _dbContext.ChangeTracker.Clear();
            return Task.CompletedTask;
        }
    }
}
