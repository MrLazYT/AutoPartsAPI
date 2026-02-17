using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;

namespace AutoPartsAPI.Domain.Interfaces.Services
{
    public interface IUserService
    {
        public Task<ReadUserDto> GetByIdAsync(string id);
        public Task<List<ReadUserDto>> GetAllAsync();
        public Task<CreateUserDto> AddAsync(CreateUserDto createUserDto);
        public Task<UpdateUserDto> UpdateAsync(UpdateUserDto updateUserDto);
        public Task<ReadUserDto> DeleteAsync(string id);
    }
}
