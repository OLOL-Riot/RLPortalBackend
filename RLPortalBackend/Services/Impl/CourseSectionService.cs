using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.CourseSection;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class CourseSectionService : ICourseSectionService
    {

        private readonly ICourseSectionRepository _courseSectionRepository;
        private readonly IMapper _mapper;

        public CourseSectionService(ICourseSectionRepository courseSectionRepository, IMapper mapper)
        {
            _courseSectionRepository = courseSectionRepository;
            _mapper = mapper;
        }



        public async Task<CourseSectionDto> CreateAsync(NewCourseSectionDto newCourseSectionDto)
        {
            CourseSectionEntity courseSectionEntity = _mapper.Map<CourseSectionEntity>(newCourseSectionDto);
            await _courseSectionRepository.CreateAsync(courseSectionEntity);
            CourseSectionDto dto = _mapper.Map<CourseSectionDto>(courseSectionEntity);
            return dto;
        }

        public async Task<ICollection<CourseSectionDto>> GetAsync()
        {
            ICollection<CourseSectionEntity> courseSectionEntities = await _courseSectionRepository.GetAsync();
            ICollection<CourseSectionDto> dtos = _mapper.Map<ICollection<CourseSectionDto>>(courseSectionEntities);
            return dtos;
        }

        public async Task<CourseSectionDto> GetByIdAsync(Guid id)
        {
            CourseSectionEntity courseSectionEntity = await _courseSectionRepository.GetAsync(id);
            CourseSectionDto dto = _mapper.Map<CourseSectionDto>(courseSectionEntity);
            return dto;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _courseSectionRepository.RemoveAsync(id);
        }

        public Task UpdateAsync(Guid id, NewCourseSectionDto newCourseSectionDto)
        {
            throw new NotImplementedException();
        }
    }
}
