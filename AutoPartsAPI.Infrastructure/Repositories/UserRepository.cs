using AutoPartsAPI.Infrastructure.Data;
using AutoPartsAPI.Infrastructure.Entities;
using AutoPartsAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AutoPartsDBContext _context;

        public UserRepository(AutoPartsDBContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            User? user = await _context.Users.FindAsync(id);

            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            List<User> users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteAsync(string id)
        {
            User? user = await GetByIdAsync(id);

            if (user is not null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }

            
            return user;

        }
    }
}
