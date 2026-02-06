using AutoMapper;
using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;
using AutoPartsAPI.Domain.Interfaces.Services;
using AutoPartsAPI.Infrastructure.Entities;
using AutoPartsAPI.Infrastructure.Interfaces;

namespace AutoPartsAPI.Domain.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IEntityRepository<OrderStatus> _repository;
        private readonly IMapper _mapper;

        public OrderStatusService(IEntityRepository<OrderStatus> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReadOrderStatusDto> GetById(int id)
        {
            OrderStatus? orderStatus = await _repository.GetByIdAsync(id);

            if (orderStatus == null)
            {
                throw new Exception($"OrderStatus with id = {id} not found.");
            }

            return _mapper.Map<ReadOrderStatusDto>(orderStatus);
        }

        public async Task<List<ReadOrderStatusDto>> GetAll()
        {
            List<OrderStatus> orderStatuses = await _repository.GetAllAsync();

            return _mapper.Map<List<ReadOrderStatusDto>>(orderStatuses);
        }

        public async Task Add(CreateOrderStatusDto createOrderStatusDto)
        {
            OrderStatus orderStatus = _mapper.Map<OrderStatus>(createOrderStatusDto);

            await _repository.AddAsync(orderStatus);
        }

        public async Task Update(UpdateOrderStatusDto updateOrderStatusDto)
        {
            OrderStatus orderStatus = _mapper.Map<OrderStatus>(updateOrderStatusDto);

            await _repository.UpdateAsync(orderStatus);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
