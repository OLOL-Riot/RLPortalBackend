using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Theory;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class TheoryService : ITheoryService
    {

        private readonly ITheoryRepository _repository;
        private readonly IMapper _mapper;

        public TheoryService(ITheoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TheoryDto> CreateAsync(NoIdTheoryDto theoryDto)
        {
            TheoryEntity theoryEntity = _mapper.Map<TheoryEntity>(theoryDto);

            IEnumerable<TheorySectionDto> createTheorySectionDtos = theoryDto.TheorySectionDtos;
            IEnumerable<TheorySectionEntity> theorySectionEntities = _mapper.Map<IEnumerable<TheorySectionEntity>>(createTheorySectionDtos);

            theoryEntity.TheorySectionEntities = theorySectionEntities.ToList();
            await _repository.CreateAsync(theoryEntity);
            TheoryDto dto = _mapper.Map<TheoryDto>(theoryEntity);
            return dto;
        }

        public async Task<ICollection<TheoryDto>> GetAsync()
        {
            ICollection<TheoryEntity> theoryEntities = await _repository.GetAsync();
            ICollection<TheoryDto> theoryDtos = _mapper.Map<ICollection<TheoryDto>>(theoryEntities);
            return theoryDtos;

        }

        public async Task<TheoryDto> GetByIdAsync(Guid id)
        {
            TheoryEntity theoryEntity = await _repository.GetAsync(id);
            TheoryDto theoryDto = _mapper.Map<TheoryDto>(theoryEntity);
            return theoryDto;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, NoIdTheoryDto updateTheoryDto)
        {
            TheoryDto dto = _mapper.Map<TheoryDto>(updateTheoryDto);
            dto.Id = id;
            ICollection<TheorySectionEntity> theorySectionEntities = _mapper.Map<ICollection<TheorySectionEntity>>(updateTheoryDto.TheorySectionDtos);
            TheoryEntity newEntity = _mapper.Map<TheoryEntity>(dto);
            newEntity.TheorySectionEntities = theorySectionEntities;
            await _repository.UpdateAsync(id, newEntity);
        }
    }
}
