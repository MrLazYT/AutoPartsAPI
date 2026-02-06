using AutoMapper;
using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;
using AutoPartsAPI.Infrastructure.Entities;

namespace AutoPartsAPI.Domain.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, ReadUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();

            CreateMap<OrderStatus, CreateOrderStatusDto>().ReverseMap();
            CreateMap<OrderStatus, ReadOrderStatusDto>().ReverseMap();
            CreateMap<OrderStatus, UpdateOrderStatusDto>().ReverseMap();
        }
    }
}
