using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;
using AutoPartsAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<ReadUserDto> readUserDtos = await _service.GetAllAsync();

            return Ok(readUserDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                ReadUserDto readUserDto = await _service.GetByIdAsync(id);

                return Ok(readUserDto);
            } catch (KeyNotFoundException)
            {
                return NotFound();
            }

        }

        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] CreateUserDto createUserDto)
        {
            await _service.AddAsync(createUserDto);

            return Ok(createUserDto);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            await _service.UpdateAsync(updateUserDto);

            return Ok(updateUserDto);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            ReadUserDto readUserDto = await _service.DeleteAsync(id);

            if (readUserDto == null)
            {
                return NotFound();
            }

            return Ok(readUserDto);
        }
    }
}
