namespace POS.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> 
        where Entity : class
    {
        Task<Entity> AddAsync(Entity entity);
        Task<Entity> UpdateAsync(Entity entity);
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<Entity?> GetByIdAsync(int id);
        Task DeleteAsync(Entity entity);
        Task<int> GetTotalRows();
    }
}
