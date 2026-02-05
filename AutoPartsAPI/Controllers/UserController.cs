using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;
using AutoPartsAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAll()
        {
            List<ReadUserDto> users = await _service.GetAll();

            return Ok(users);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetById(string userId)
        {
            ReadUserDto user = await _service.GetById(userId);

            return Ok(user);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            await _service.Create(createUserDto);

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            await _service.Update(updateUserDto);

            return Ok();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.Delete(id);

            return Ok();
        }
    }
}
