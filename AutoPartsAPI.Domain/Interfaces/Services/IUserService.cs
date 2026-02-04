using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;

namespace AutoPartsAPI.Domain.Interfaces.Services
{
    public interface IUserService
    {
        public Task<ReadUserDto> GetById(string id);
        public Task<List<ReadUserDto>> GetAll();
        public Task Create(CreateUserDto createUserDto);
        public Task Update(UpdateUserDto updateUserDto);
        public Task Delete(string id);
    }
}
