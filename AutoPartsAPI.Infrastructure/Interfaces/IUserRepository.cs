using AutoPartsAPI.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoPartsAPI.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetByIdAsync(string id);
        public Task<List<User>> GetAllAsync();
        public Task AddAsync(User user);
        public Task UpdateAsync(User user);
        public Task DeleteAsync(string id);
        public Task SaveChangesAsync();
    }
}
