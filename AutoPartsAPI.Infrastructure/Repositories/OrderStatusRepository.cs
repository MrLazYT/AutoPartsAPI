using AutoPartsAPI.Infrastructure.Data;
using AutoPartsAPI.Infrastructure.Entities;
using AutoPartsAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsAPI.Infrastructure.Repositories
{
    public class OrderStatusRepository : IEntityRepository<OrderStatus>
    {
        private readonly AutoPartsDBContext _context;

        public OrderStatusRepository(AutoPartsDBContext context)
        {
            _context = context;
        }

        public async Task<OrderStatus?> GetByIdAsync(int id)
        {
            OrderStatus? orderStatus = await _context.OrderStatuses.FindAsync(id);

            return orderStatus;
        }

        public async Task<List<OrderStatus>> GetAllAsync()
        {
            List<OrderStatus> orderStatuses = await _context.OrderStatuses.ToListAsync();

            return orderStatuses;
        }

        public async Task<OrderStatus> AddAsync(OrderStatus orderStatus)
        {
            await _context.OrderStatuses.AddAsync(orderStatus);
            await _context.SaveChangesAsync();

            return orderStatus;
        }

        public async Task<OrderStatus> UpdateAsync(OrderStatus orderStatus)
        {
            _context.Update(orderStatus);
            await _context.SaveChangesAsync();

            return orderStatus;
        }

        public async Task<OrderStatus?> DeleteAsync(int id)
        {
            OrderStatus? orderStatus = await GetByIdAsync(id);

            if (orderStatus != null)
            {
                _context.OrderStatuses.Remove(orderStatus);
                await _context.SaveChangesAsync();
            }

            return orderStatus;
        }
    }
}
