using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;
using AutoPartsAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsAPI.Controllers
{
    [ApiController]
    [Route("api/order-statuses")]
    public class OrderStatusController : ControllerBase
    {
        private readonly IEntityService<ReadOrderStatusDto, CreateOrderStatusDto, UpdateOrderStatusDto> _service;
        
        public OrderStatusController(IEntityService<ReadOrderStatusDto, CreateOrderStatusDto, UpdateOrderStatusDto> service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<ReadOrderStatusDto> orderStatuses = await _service.GetAllAsync();

            return Ok(orderStatuses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ReadOrderStatusDto orderStatus = await _service.GetByIdAsync(id);

                return Ok(orderStatus);
            } catch (Exception)
            {
                return NotFound();
            }
                 
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] CreateOrderStatusDto createOrderStatusDto)
        {
            CreateOrderStatusDto orderStatus = await _service.AddAsync(createOrderStatusDto);

            return Ok(orderStatus);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderStatusDto updateOrderStatusDto)
        {
            UpdateOrderStatusDto orderStatus = await _service.UpdateAsync(updateOrderStatusDto);

            return Ok(orderStatus);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ReadOrderStatusDto orderStatus = await _service.DeleteAsync(id);

            return Ok(orderStatus);
        }
    }
}
