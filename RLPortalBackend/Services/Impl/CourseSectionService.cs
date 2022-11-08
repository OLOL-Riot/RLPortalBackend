using AutoMapper;
using Microsoft.OpenApi.Writers;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.CourseSection;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Models.Theory;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class CourseSectionService : ICourseSectionService
    {

        private readonly ICourseSectionRepository _courseSectionRepository;
        private readonly IMapper _mapper;
        private readonly ITestService _testService;
        private readonly ITheoryRepository _theoryRepository;

        public CourseSectionService(ICourseSectionRepository courseSectionRepository, IMapper mapper, ITestService testService, ITheoryRepository theoryRepository)
        {
            _courseSectionRepository = courseSectionRepository;
            _mapper = mapper;
            _testService = testService;
            _theoryRepository = theoryRepository;
        }



        public async Task<CourseSectionDto> CreateAsync(NewCourseSectionDto newCourseSectionDto)
        {
            CourseSectionEntity courseSectionEntity = _mapper.Map<CourseSectionEntity>(newCourseSectionDto);

            ICollection<NoIdTheoryDto> theories = newCourseSectionDto.TheoryDtos;
            ICollection<TheoryEntity> theoryEntities = _mapper.Map<ICollection<TheoryEntity>>(theories);

            await _theoryRepository.CreateManyAsync(theoryEntities);

            ICollection<Guid> theoryGuids = theoryEntities.Select(e => e.Id).ToList();
            courseSectionEntity.TheoryEntityId = theoryGuids;

            ICollection<Guid> testGuids = new List<Guid>();
            ICollection<CreateTest> tests = newCourseSectionDto.TestDtos;
            foreach (CreateTest test in tests)
            {
                var dtoWithId = await _testService.CreateAsync(test);
                testGuids.Add(dtoWithId.Id);
            }
            courseSectionEntity.TestEntityId = testGuids;

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

        public async Task UpdateAsync(Guid id, NewCourseSectionDto newCourseSectionDto)
        {
            CourseSectionEntity courseSectionEntity = _mapper.Map<CourseSectionEntity>(newCourseSectionDto);

        }

        public async Task<ICollection<PreviewCourseDto>> GetPreviewCourse(ICollection<Guid> ids)
        {
            ICollection<CourseSectionEntity> entities = await _courseSectionRepository.GetAsync(ids);
            ICollection<PreviewCourseDto> previews = _mapper.Map<ICollection<PreviewCourseDto>>(entities);
            return previews;

        }
    }
}
