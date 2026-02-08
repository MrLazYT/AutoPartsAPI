using AutoMapper;
using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;
using AutoPartsAPI.Domain.Interfaces.Services;
using AutoPartsAPI.Infrastructure.Entities;
using AutoPartsAPI.Infrastructure.Interfaces;

namespace AutoPartsAPI.Domain.Services
{
    public class OrderStatusService : IEntityService<ReadOrderStatusDto, CreateOrderStatusDto, UpdateOrderStatusDto>
    {
        private readonly IEntityRepository<OrderStatus> _repository;
        private readonly IMapper _mapper;

        public OrderStatusService(IEntityRepository<OrderStatus> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReadOrderStatusDto> GetByIdAsync(int id)
        {
            OrderStatus? orderStatus = await _repository.GetByIdAsync(id);

            if (orderStatus == null)
            {
                throw new Exception($"OrderStatus with id = {id} not found.");
            }

            return _mapper.Map<ReadOrderStatusDto>(orderStatus);
        }

        public async Task<List<ReadOrderStatusDto>> GetAllAsync()
        {
            List<OrderStatus> orderStatuses = await _repository.GetAllAsync();

            return _mapper.Map<List<ReadOrderStatusDto>>(orderStatuses);
        }

        public async Task<CreateOrderStatusDto> AddAsync(CreateOrderStatusDto createOrderStatusDto)
        {
            OrderStatus orderStatus = _mapper.Map<OrderStatus>(createOrderStatusDto);

            await _repository.AddAsync(orderStatus);

            return createOrderStatusDto;
        }

        public async Task<UpdateOrderStatusDto> UpdateAsync(UpdateOrderStatusDto updateOrderStatusDto)
        {
            OrderStatus orderStatus = _mapper.Map<OrderStatus>(updateOrderStatusDto);

            await _repository.UpdateAsync(orderStatus);

            return updateOrderStatusDto;
        }

        public async Task<ReadOrderStatusDto> DeleteAsync(int id)
        {
            OrderStatus? orderStatus = await _repository.DeleteAsync(id);

            return _mapper.Map<ReadOrderStatusDto>(orderStatus);
        }
    }
}
