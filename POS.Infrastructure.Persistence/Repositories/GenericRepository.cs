using Microsoft.EntityFrameworkCore;
using POS.Core.Application.Common.DTOs;
using POS.Core.Application.Interfaces.Repositories;
using POS.Infrastructure.Persistence.Contexts;
using POS.Infrastructure.Persistence.Utilities;

namespace POS.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity>
        where Entity : class
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Entity> AddAsync(Entity entity)
        {
            await _dbContext.Set<Entity>().AddAsync(entity);
            return await Task.FromResult(entity);
        }

        public async Task<Entity> UpdateAsync(Entity entity)
        {
            _dbContext.Update(entity);
            return await Task.FromResult(entity);
        }

        public Task DeleteAsync(Entity entity)
        {
            _dbContext.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Entity>> GetAllAsync(PaginationFilter filter)
        {
            var queryable = _dbContext.Set<Entity>().AsQueryable();

            return await queryable
                            .Paginate(filter.Page, filter.RecordsPerPage)
                            .ToListAsync();
        }

        public async Task<Entity?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Entity>().FindAsync(id);
        }

        public async Task<int> GetTotalRowsAsync()
        {
            return await _dbContext.Set<Entity>().CountAsync();
        }
    }
}
