using AutoPartsAPI.Infrastructure.Data;
using AutoPartsAPI.Infrastructure.Entities;
using AutoPartsAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsAPI.Infrastructure.Repositories
{
    public class VendorsRepository : IEntityRepository<Vendor>
    {
        private readonly AutoPartsDBContext _context;

        public VendorsRepository(AutoPartsDBContext context)
        {
            _context = context;
        }

        public async Task<Vendor?> GetByIdAsync(int id)
        {
            Vendor? vendor = await _context.Vendors.FindAsync(id);

            return vendor;
        }

        public async Task<List<Vendor>> GetAllAsync()
        {
            List<Vendor> vendors = await _context.Vendors.ToListAsync();

            return vendors;
        }

        public async Task<Vendor> AddAsync(Vendor vendor)
        {
            await _context.AddAsync(vendor);
            await _context.SaveChangesAsync();

            return vendor;
        }

        public async Task<Vendor> UpdateAsync(Vendor vendor)
        {
            _context.Update(vendor);
            await _context.SaveChangesAsync();

            return vendor;
        }

        public async Task<Vendor?> DeleteAsync(int id)
        {
            Vendor? vendor = await GetByIdAsync(id);

            if (vendor != null)
            {
                _context.Remove(vendor);
                await _context.SaveChangesAsync();
            }

            return vendor;
        }
    }
}