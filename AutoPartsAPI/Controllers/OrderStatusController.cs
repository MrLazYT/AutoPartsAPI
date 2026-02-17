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
            List<ReadOrderStatusDto> readOrderStatusDtos = await _service.GetAllAsync();

            return Ok(readOrderStatusDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ReadOrderStatusDto readOrderStatusDto = await _service.GetByIdAsync(id);

                return Ok(readOrderStatusDto);
            } catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] CreateOrderStatusDto createOrderStatusDto)
        {
            await _service.AddAsync(createOrderStatusDto);

            return Ok(createOrderStatusDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderStatusDto updateOrderStatusDto)
        {
            await _service.UpdateAsync(updateOrderStatusDto);

            return Ok(updateOrderStatusDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ReadOrderStatusDto readOrderStatusDto = await _service.DeleteAsync(id);

            if (readOrderStatusDto == null)
            {
                return NotFound();
            }

            return Ok(readOrderStatusDto);
        }
    }
}
