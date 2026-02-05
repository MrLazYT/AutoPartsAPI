using AutoPartsAPI.Infrastructure.Data;
using AutoPartsAPI.Infrastructure.Entities;
using AutoPartsAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public Task UpdateAsync(User user)
        {
            _context.Users.Update(user);

            return Task.CompletedTask;
        }

        public async Task DeleteAsync(string id)
        {
            User? user = await GetByIdAsync(id);

            if (user is null)
            {
                throw new KeyNotFoundException($"Entity User with id={id} not found.");
            }

            _context.Users.Remove(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
