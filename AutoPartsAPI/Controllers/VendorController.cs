using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;
using AutoPartsAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsAPI.Controllers
{
    [ApiController]
    [Route("api/vendors")]
    public class VendorController : ControllerBase
    {
        private readonly IEntityService<ReadVendorDto, CreateVendorDto, UpdateVendorDto> _service;

        public VendorController(IEntityService<ReadVendorDto, CreateVendorDto, UpdateVendorDto> service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<ReadVendorDto> readVendorDtos = await _service.GetAllAsync();

            return Ok(readVendorDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ReadVendorDto readVendorDto = await _service.GetByIdAsync(id);

                return Ok(readVendorDto);
            } catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] CreateVendorDto createVendorDto)
        {
            await _service.AddAsync(createVendorDto);

            return Ok(createVendorDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateVendorDto UpdateVendorDto)
        {
            await _service.UpdateAsync(UpdateVendorDto);

            return Ok(UpdateVendorDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ReadVendorDto readVendorDto = await _service.DeleteAsync(id);

            if (readVendorDto == null)
            {
                return NotFound();
            }

            return Ok(readVendorDto);
        }
    }
}
