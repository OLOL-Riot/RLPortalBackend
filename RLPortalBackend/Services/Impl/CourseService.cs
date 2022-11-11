using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Course;
using RLPortalBackend.Models.CourseSection;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseSectionService _courseSectionService;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, ICourseSectionService courseSectionService, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _courseSectionService = courseSectionService;
            _mapper = mapper;
        }

        public async Task<CourseDto> CreateAsync(CreateCourseDto createCourseDto)
        {
            CourseEntity newCourseEntity = _mapper.Map<CourseEntity>(createCourseDto);
            newCourseEntity.CourseSectionEntityIds = new List<Guid>();

            await _courseRepository.CreateAsync(newCourseEntity);

            CourseDto createdCourseDto = _mapper.Map<CourseDto>(newCourseEntity);
            
            return createdCourseDto;
        }

        public async Task<ICollection<PreviewCourseDto>> GetAllPreviewCourses()
        {
            ICollection<CourseEntity> courseEntities = await _courseRepository.GetCoursesAsync();

            ICollection<PreviewCourseDto> previewCourses = _mapper.Map<ICollection<PreviewCourseDto>>(courseEntities);

            return previewCourses;
        }

        public async Task<PageCourseDto> GetPageCourseByIdAsync(Guid id)
        {
            CourseEntity courseEntity = await _courseRepository.GetCourseByIdAsync(id);

            ICollection<PreviewCourseSectionDto> previewCourseSectionDtos = await _courseSectionService.GetPreviewCourseSections(courseEntity.CourseSectionEntityIds);

            PageCourseDto courseDto = _mapper.Map<PageCourseDto>(courseEntity);

            courseDto.PreviewCourseSections = previewCourseSectionDtos;

            return courseDto;
        }

        public async Task<CourseDto> GetCourseByIdAsync(Guid id)
        {
            CourseEntity courseEntity = await _courseRepository.GetCourseByIdAsync(id);

            CourseDto courseDto = _mapper.Map<CourseDto>(courseEntity);

            return courseDto;
        }

        public async Task<ICollection<CourseDto>> GetCoursesAsync()
        {
            ICollection<CourseEntity> courseEntities = await _courseRepository.GetCoursesAsync();

            ICollection<CourseDto> courseDtos = _mapper.Map<ICollection<CourseDto>>(courseEntities);

            return courseDtos;
        }

        public async Task RemoveAsync(Guid id)
        {
            CourseEntity courseEntity = await _courseRepository.GetCourseByIdAsync(id);

            foreach(var courseSectionIds in courseEntity.CourseSectionEntityIds)
            {
                await _courseSectionService.RemoveAsync(courseSectionIds);
            }

            await _courseRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, UpdateCourseDto updateCourseDto)
        {
            CourseEntity updateCourseEntity = _mapper.Map<CourseEntity>(updateCourseDto);
            updateCourseEntity.Id = id;

            await _courseRepository.UpdateAsync(id, updateCourseEntity);
        }
    }
}
