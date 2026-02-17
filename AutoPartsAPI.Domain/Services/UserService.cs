using AutoMapper;
using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;
using AutoPartsAPI.Domain.Interfaces.Services;
using AutoPartsAPI.Infrastructure.Entities;
using AutoPartsAPI.Infrastructure.Interfaces;

namespace AutoPartsAPI.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserService(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        public async Task<ReadUserDto> GetByIdAsync(string id)
        {
            User? user = await _repository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception($"User with id {id} not found.");
            }

            return _mapper.Map<ReadUserDto>(user);
        }

        public async Task<List<ReadUserDto>> GetAllAsync()
        {
            List<User> users = await _repository.GetAllAsync();

            return _mapper.Map<List<ReadUserDto>>(users);
        }

        public async Task<CreateUserDto> AddAsync(CreateUserDto createUserDto)
        {
            User user = _mapper.Map<User>(createUserDto);

            await _repository.AddAsync(user);

            return createUserDto;
        }
        
        public async Task<UpdateUserDto> UpdateAsync(UpdateUserDto updateUserDto)
        {
            User user = _mapper.Map<User>(updateUserDto);

            await _repository.UpdateAsync(user);

            return updateUserDto;
        }

        public async Task<ReadUserDto> DeleteAsync(string id)
        {
            User? user = await _repository.DeleteAsync(id);

            if (user == null)
            {
                throw new Exception($"User with id = {id} not found.");
            }

            return _mapper.Map<ReadUserDto>(user);
        }
    }
}