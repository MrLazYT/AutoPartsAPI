using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;
using AutoPartsAPI.Domain.Helpers;
using AutoPartsAPI.Domain.Interfaces.Services;
using AutoPartsAPI.Domain.Services;
using AutoPartsAPI.Infrastructure.Data;
using AutoPartsAPI.Infrastructure.Entities;
using AutoPartsAPI.Infrastructure.Interfaces;
using AutoPartsAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AutoPartsDBContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );

            builder.Services
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AutoPartsDBContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddCors(options => options.AddPolicy(
                "CorsPolicy",
                builder =>
                {
                    builder.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
                )
            );

            builder.Services.AddAutoMapper(
                cfg => cfg.LicenseKey = builder.Configuration["AutoMapper:LicenseKey"],
                typeof(MappingProfile)
            );

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services
                .AddScoped<
                    IEntityService<ReadOrderStatusDto, CreateOrderStatusDto, UpdateOrderStatusDto>,
                    OrderStatusService>();
            builder.Services
                .AddScoped<IEntityService<ReadVendorDto, CreateVendorDto, UpdateVendorDto>, VendorService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IEntityRepository<OrderStatus>, OrderStatusRepository>();
            builder.Services.AddScoped<IEntityRepository<Vendor>, VendorsRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}