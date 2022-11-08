using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Exceptions;
using RLPortalBackend.Models.CourseSection;
using RLPortalBackend.Models.Theory;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class CourseSectionService : ICourseSectionService
    {

        private readonly ICourseSectionRepository _courseSectionRepository;
        private readonly IMapper _mapper;
        private readonly ITheoryRepository _theoryRepository;
        private readonly ITestRepository _testRepository;

        public CourseSectionService(ICourseSectionRepository courseSectionRepository, IMapper mapper, ITheoryRepository theoryRepository, ITestRepository testRepository)
        {
            _courseSectionRepository = courseSectionRepository;
            _mapper = mapper;
            _theoryRepository = theoryRepository;
            _testRepository = testRepository;
        }



        public async Task<CourseSectionDto> CreateAsync(NewCourseSectionDto newCourseSectionDto)
        {
            CourseSectionEntity courseSectionEntity = _mapper.Map<CourseSectionEntity>(newCourseSectionDto);
            var testId = Guid.NewGuid();
            var theoryId = Guid.NewGuid();
            TestEntity testEntity = new(testId, "", new List<Guid>());
            await _testRepository.CreateAsync(testEntity);
            await _theoryRepository.CreateAsync(new TheoryEntity(theoryId, "", "", "", new List<TheorySectionEntity>()));
            courseSectionEntity.TestEntityId = testId;
            courseSectionEntity.TheoryEntityId = theoryId;
            await _courseSectionRepository.CreateAsync(courseSectionEntity);
            CourseSectionDto dto = _mapper.Map<CourseSectionDto>(courseSectionEntity);
            dto.TheoryDto = _mapper.Map<TheoryDto>(await _theoryRepository.GetAsync(theoryId));
            return dto;

        }

        public async Task<ICollection<CourseSectionDto>> GetAsync()
        {
            ICollection<CourseSectionEntity> courseSectionEntities = await _courseSectionRepository.GetAsync();
            ICollection<CourseSectionDto> dtos = new List<CourseSectionDto>();
            foreach(var courseSectionEntity in courseSectionEntities)
            {
                var dto = _mapper.Map<CourseSectionDto>(courseSectionEntity);
                dto.TheoryDto = _mapper.Map<TheoryDto>(await _theoryRepository.GetAsync(courseSectionEntity.TheoryEntityId));
                dtos.Add(dto);
            }
            //ICollection<CourseSectionDto> dtos = _mapper.Map<ICollection<CourseSectionDto>>(courseSectionEntities);
            return dtos;
        }

        public async Task<CourseSectionDto> GetByIdAsync(Guid id)
        {
            if (await _courseSectionRepository.GetAsync(id) == null)
            {
                throw new CourseSectionNotFoundException($"Course section {id} not found");
            }
            CourseSectionEntity courseSectionEntity = await _courseSectionRepository.GetAsync(id);
            CourseSectionDto dto = _mapper.Map<CourseSectionDto>(courseSectionEntity);
            dto.TheoryDto = _mapper.Map<TheoryDto>(await _theoryRepository.GetAsync(courseSectionEntity.TheoryEntityId));
            return dto;
        }

        public async Task RemoveAsync(Guid id)
        {
            if (await _courseSectionRepository.GetAsync(id) == null)
            {
                throw new CourseSectionNotFoundException($"Course section {id} not found");
            }
            await _courseSectionRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, NewCourseSectionDto newCourseSectionDto)
        {
            if (await _courseSectionRepository.GetAsync(id) == null)
            {
                throw new CourseSectionNotFoundException($"Course section {id} not found");
            }
            CourseSectionEntity courseSectionEntity = _mapper.Map<CourseSectionEntity>(newCourseSectionDto);
            var entity = await _courseSectionRepository.GetAsync(id);
            courseSectionEntity.TheoryEntityId = entity.TheoryEntityId;
            courseSectionEntity.TestEntityId = entity.TestEntityId;
            courseSectionEntity.Id = id;
            await _courseSectionRepository.UpdateAsync(id, courseSectionEntity);

        }

        public async Task<ICollection<PreviewCourseDto>> GetPreviewCourse(ICollection<Guid> ids)
        {
            ICollection<CourseSectionEntity> entities = await _courseSectionRepository.GetAsync(ids);
            ICollection<PreviewCourseDto> previews = _mapper.Map<ICollection<PreviewCourseDto>>(entities);
            return previews;

        }
    }
}
