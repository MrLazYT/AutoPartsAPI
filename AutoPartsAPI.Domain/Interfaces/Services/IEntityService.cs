namespace AutoPartsAPI.Domain.Interfaces.Services
{
    public interface IEntityService<ReadDto, CreateDto, UpdateDto>
    {
        public Task<ReadDto> GetByIdAsync(int id);
        public Task<List<ReadDto>> GetAllAsync();
        public Task<CreateDto> AddAsync(CreateDto createEntityDto);
        public Task<UpdateDto> UpdateAsync(UpdateDto updateEntityDto);
        public Task<ReadDto> DeleteAsync(int id);
    }
}
