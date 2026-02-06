using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;
using AutoPartsAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AutoPartsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _service;
        
        public OrderStatusController(IOrderStatusService service)
        {
            _service = service;
        }

        [HttpGet("order-statuses")]
        public async Task<IActionResult> GetAll()
        {
            List<ReadOrderStatusDto> orderStatuses = await _service.GetAll();

            return Ok(orderStatuses);
        }

        [HttpGet("order-status/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ReadOrderStatusDto orderStatus = await _service.GetById(id);

            return Ok(orderStatus);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] CreateOrderStatusDto createOrderStatusDto)
        {
            await _service.Add(createOrderStatusDto);

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderStatusDto updateOrderStatusDto)
        {
            await _service.Update(updateOrderStatusDto);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);

            return Ok();
        }
    }
}
