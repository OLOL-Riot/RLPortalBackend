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

            await _courseRepository.CreateAsync(newCourseEntity);

            CourseDto createdCourseDto = _mapper.Map<CourseDto>(createCourseDto);

            return createdCourseDto;
        }

        public async Task<ICollection<PreviewCourseDto>> GetAllPreviewCourses()
        {
            ICollection<CourseEntity> courseEntities = await _courseRepository.GetCoursesAsync();

            ICollection<PreviewCourseDto> previewCourses = _mapper.Map<ICollection<PreviewCourseDto>>(courseEntities);

            return previewCourses;
        }

        public async Task<CourseDto> GetCourseByIdAsync(Guid id)
        {
            CourseEntity courseEntity = await _courseRepository.GetCourseByIdAsync(id);

            ICollection<PreviewCourseSectionDto> previewCourseSectionDtos = await _courseSectionService.GetPreviewCourseSections(courseEntity.CourseSectionEntityIds);

            CourseDto courseDto = _mapper.Map<CourseDto>(courseEntity);

            courseDto.PreviewCourseSections = previewCourseSectionDtos;

            return courseDto;
        }

        public async Task<ICollection<CourseDto>> GetCoursesAsync()
        {
            ICollection<CourseEntity> courseEntities = await _courseRepository.GetCoursesAsync();

            ICollection<CourseDto> courseDtos = _mapper.Map<ICollection<CourseDto>>(courseEntities);

            // Preview Courses Sections adding to courseDtos
            for (int i = 0; i < courseEntities.Count; i++)
            {
                CourseEntity courseEntity = courseEntities.ElementAt(i);
                CourseDto courseDto = courseDtos.First(x => x.Id == courseEntity.Id);

                ICollection<PreviewCourseSectionDto> previewCourseSectionDtos = await _courseSectionService.GetPreviewCourseSections(courseEntity.CourseSectionEntityIds);

                courseDto = _mapper.Map<CourseDto>(courseEntity);

                courseDto.PreviewCourseSections = previewCourseSectionDtos;
            }


            return courseDtos;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _courseRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, UpdateCourseDto updateCourseDto)
        {
            CourseEntity updateCourseEntity = _mapper.Map<CourseEntity>(updateCourseDto);

            await _courseRepository.UpdateAsync(id, updateCourseEntity);
        }
    }
}
