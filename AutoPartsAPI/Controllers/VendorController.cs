using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;
using AutoPartsAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            List<ReadVendorDto> vendors = await _service.GetAllAsync();

            return Ok(vendors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ReadVendorDto vendor = await _service.GetByIdAsync(id);

                return Ok(vendor);
            } catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] CreateVendorDto vendor)
        {
            await _service.AddAsync(vendor);

            return Ok(vendor);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateVendorDto vendor)
        {
            await _service.UpdateAsync(vendor);

            return Ok(vendor);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ReadVendorDto vendor = await _service.DeleteAsync(id);

            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor);
        }
    }
}
