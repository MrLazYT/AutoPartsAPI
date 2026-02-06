using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;

namespace AutoPartsAPI.Domain.Interfaces.Services
{
    public interface IOrderStatusService
    {
        public Task<ReadOrderStatusDto> GetById(int id);
        public Task<List<ReadOrderStatusDto>> GetAll();
        public Task Add(CreateOrderStatusDto createOrderStatusDto);
        public Task Update(UpdateOrderStatusDto updateOrderStatusDto);
        public Task Delete(int id);
    }
}
