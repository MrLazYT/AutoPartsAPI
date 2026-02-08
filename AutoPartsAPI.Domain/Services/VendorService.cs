using AutoMapper;
using AutoPartsAPI.Domain.DTO.Create;
using AutoPartsAPI.Domain.DTO.Read;
using AutoPartsAPI.Domain.DTO.Update;
using AutoPartsAPI.Domain.Interfaces.Services;
using AutoPartsAPI.Infrastructure.Entities;
using AutoPartsAPI.Infrastructure.Interfaces;

namespace AutoPartsAPI.Domain.Services
{
    public class VendorService : IEntityService<ReadVendorDto, CreateVendorDto, UpdateVendorDto>
    {
        private readonly IEntityRepository<Vendor> _repository;
        private readonly IMapper _mapper;

        public VendorService(IEntityRepository<Vendor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReadVendorDto> GetByIdAsync(int id)
        {
            Vendor? vendor = await _repository.GetByIdAsync(id);

            return _mapper.Map<ReadVendorDto>(vendor);
        }

        public async Task<List<ReadVendorDto>> GetAllAsync()
        {
            List<Vendor> vendors = await _repository.GetAllAsync();

            return _mapper.Map<List<ReadVendorDto>>(vendors);
        }

        public async Task<CreateVendorDto> AddAsync(CreateVendorDto createVendorDto)
        {
            Vendor vendor = _mapper.Map<Vendor>(createVendorDto);

            await _repository.AddAsync(vendor);

            return createVendorDto;
        }

        public async Task<UpdateVendorDto> UpdateAsync(UpdateVendorDto updateVendorDto)
        {
            Vendor vendor = _mapper.Map<Vendor>(updateVendorDto);

            await _repository.UpdateAsync(vendor);

            return updateVendorDto;
        }

        public async Task<ReadVendorDto> DeleteAsync(int id)
        {
            Vendor? vendor = await _repository.DeleteAsync(id);

            return _mapper.Map<ReadVendorDto>(vendor);
        }
    }
}