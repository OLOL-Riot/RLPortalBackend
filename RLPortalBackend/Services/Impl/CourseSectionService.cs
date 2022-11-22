﻿using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Exceptions;
using RLPortalBackend.Models.CourseSection;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Models.Theory;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class CourseSectionService : ICourseSectionService
    {

        private readonly ICourseSectionRepository _courseSectionRepository;
        private readonly IMapper _mapper;
        private readonly ITheoryService _theoryService;
        private readonly ITestService _testService;

        public CourseSectionService(ICourseSectionRepository courseSectionRepository, IMapper mapper, ITheoryService theoryService, ITestService testService)
        {
            _courseSectionRepository = courseSectionRepository;
            _mapper = mapper;
            _theoryService = theoryService;
            _testService = testService;
        }



        public async Task<CourseSectionDto> CreateAsync(NewCourseSectionDto newCourseSectionDto)
        {
            CourseSectionEntity courseSectionEntity = _mapper.Map<CourseSectionEntity>(newCourseSectionDto);

            CreateTestDto createTest = new CreateTestDto();
            createTest.Name = "";
            createTest.Exercises = new List<NewExerciseDto>();

            Guid testId = (await _testService.CreateAsync(createTest)).Id;

            NewTheoryDto newTheoryDto = new NewTheoryDto();

            newTheoryDto.Name = "";
            newTheoryDto.Description = "";
            newTheoryDto.ShortDescription = "";
            newTheoryDto.TheorySectionDtos = new List<TheorySectionDto>();

            Guid theoryId = (await _theoryService.CreateAsync(newTheoryDto)).Id;

            courseSectionEntity.TestEntityId = testId;
            courseSectionEntity.TheoryEntityId = theoryId;

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

        public async Task<PageCourseSectionDto> GetPageCourseSectionByIdAsync(Guid id)
        {
            if (await _courseSectionRepository.GetAsync(id) == null)
            {
                throw new CourseSectionNotFoundException($"Course section {id} not found");
            }

            CourseSectionEntity courseSectionEntity = await _courseSectionRepository.GetAsync(id);

            PageCourseSectionDto dto = _mapper.Map<PageCourseSectionDto>(courseSectionEntity);

            dto.TheoryDto = await _theoryService.GetByIdAsync(courseSectionEntity.TheoryEntityId);

            return dto;
        }

        public async Task<CourseSectionDto> GetCourseSectionByIdAsync(Guid id)
        {
            CourseSectionEntity courseSectionEntity = await _courseSectionRepository.GetAsync(id);

            if (courseSectionEntity == null)
            {
                throw new CourseSectionNotFoundException($"Course section {id} not found");
            }

            CourseSectionDto courseSectionDto = _mapper.Map<CourseSectionDto>(courseSectionEntity);

            return courseSectionDto;
        }

        public async Task RemoveAsync(Guid id)
        {
            CourseSectionEntity courseSectionEntity = await _courseSectionRepository.GetAsync(id);

            if (courseSectionEntity == null)
            {
                throw new CourseSectionNotFoundException($"Course section {id} not found");
            }

            await _courseSectionRepository.RemoveAsync(id);
            await _theoryService.RemoveAsync(courseSectionEntity.TheoryEntityId);
            await _testService.RemoveAsync(courseSectionEntity.TestEntityId);
        }

        public async Task UpdateAsync(Guid id, NewCourseSectionDto newCourseSectionDto)
        {
            CourseSectionEntity oldCourseSectionEntity = await _courseSectionRepository.GetAsync(id);

            if (oldCourseSectionEntity == null)
            {
                throw new CourseSectionNotFoundException($"Course section {id} not found");
            }

            CourseSectionEntity courseSectionEntity = _mapper.Map<CourseSectionEntity>(newCourseSectionDto);

            courseSectionEntity.TheoryEntityId = oldCourseSectionEntity.TheoryEntityId;
            courseSectionEntity.TestEntityId = oldCourseSectionEntity.TestEntityId;
            courseSectionEntity.Id = id;

            await _courseSectionRepository.UpdateAsync(id, courseSectionEntity);

        }

        public async Task<ICollection<PreviewCourseSectionDto>> GetPreviewCourseSections(ICollection<Guid> ids)
        {
            ICollection<CourseSectionEntity> entities = await _courseSectionRepository.GetAsync(ids);

            ICollection<PreviewCourseSectionDto> previews = _mapper.Map<ICollection<PreviewCourseSectionDto>>(entities);
            
            return previews;

        }
    }
}
