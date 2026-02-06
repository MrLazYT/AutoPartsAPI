namespace AutoPartsAPI.Infrastructure.Interfaces
{
    public interface IEntityRepository<Entity> where Entity : class
    {
        public Task<Entity?> GetByIdAsync(int id);
        public Task<List<Entity>> GetAllAsync();
        public Task<Entity> AddAsync(Entity entity);
        public Task<Entity> UpdateAsync(Entity entity);
        public Task<Entity?> DeleteAsync(int id);
    }
}
