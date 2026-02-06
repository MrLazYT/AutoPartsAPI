using AutoPartsAPI.Infrastructure.Entities;

namespace AutoPartsAPI.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetByIdAsync(string id);
        public Task<List<User>> GetAllAsync();
        public Task<User> AddAsync(User user);
        public Task<User> UpdateAsync(User user);
        public Task<User?> DeleteAsync(string id);
    }
}
