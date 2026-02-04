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
        public readonly IMapper _mapper;
        public readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        
        public async Task<ReadUserDto> GetById(string id)
        {
            User? user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new Exception($"User with id {id} not found.");
            }

            return _mapper.Map<ReadUserDto>(user);
        }

        public async Task<List<ReadUserDto>> GetAll()
        {
            List<User> users = await _userRepository.GetAllAsync();

            return _mapper.Map<List<ReadUserDto>>(users);
        }

        public async Task Create(CreateUserDto createUserDto)
        {
            User user = _mapper.Map<User>(createUserDto);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }
        
        public async Task Update(UpdateUserDto updateUserDto)
        {
            User user = _mapper.Map<User>(updateUserDto);

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            await _userRepository.DeleteAsync(id);
            await _userRepository.SaveChangesAsync();
        }

    }
}
