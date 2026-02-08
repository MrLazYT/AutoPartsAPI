using AutoPartsAPI.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsAPI.Infrastructure.Data
{
    public class AutoPartsDBContext: IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

        public AutoPartsDBContext(DbContextOptions<AutoPartsDBContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>();
        }
    }
}
