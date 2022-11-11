﻿using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Course;
using RLPortalBackend.Models.CourseSection;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Models.Theory;
using RLPortalBackend.Models.VerifiedTest;

namespace RLPortalBackend.Mappers
{
    /// <summary>
    /// Mapper for <see cref="ExerciseDto"/> to <see cref="ExerciseEntity"/>
    /// Mapper for <see cref="TestDto"/> to <see cref="TestEntity"/>
    /// </summary>
    public class AppMappingProfile : Profile
    {


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public AppMappingProfile()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            // Exercise, ExerciseEntity
            CreateMap<ExerciseDto, ExerciseEntity>().ReverseMap();

            // NewExercise, ExerciseEntity
            CreateMap<NewExercise, ExerciseEntity>().ReverseMap();

            // NoRightAnswerExercise, ExerciseEntity
            CreateMap<NoRightAnswerExercise, ExerciseEntity>().ReverseMap();

            // Test, TestEntity
            CreateMap<TestDto, TestEntity>().ReverseMap();

            // NoRightAnswerTest, TestEntity
            CreateMap<NoRightAnswersTest, TestEntity>().ReverseMap();

            // CreateTest, TestEntity
            CreateMap<CreateTest, TestEntity>().ReverseMap();

            // UpdateTest, TestEntity
            CreateMap<UpdateTest, TestEntity>().ReverseMap();

            // VerifiedTestEntity, VerifiedTestDto
            CreateMap<VerifiedTestEntity, VerifiedTestDto>().ReverseMap();

            // UserAnswerEntity, UserAnswerDto
            CreateMap<VerifiedExerciseEntity, VerifiedExerciseDto>().ReverseMap();

            // VerifiedTestEntity, UpdateVerifiedTestDto
            CreateMap<VerifiedTestEntity, UpdateVerifiedTestDto>().ReverseMap();

            // CreateVerifiedTestDto, VerifiedTestDto
            CreateMap<CreateVerifiedTestDto, VerifiedTestEntity>();

            // SolvedTestDto, VerifiedTestDto
            CreateMap<SolvedTestDto, CreateVerifiedTestDto>()
                .ForMember(dest => dest.VerifiedAnswers, opt => opt.MapFrom(source => source.UserAnswers));

            // SolvedExercise, VerifiedExerciseDto
            CreateMap<SolvedExercise, VerifiedExerciseDto>();

            // CreateVerifiedTestDto, VerifiedTestDto
            CreateMap<CreateVerifiedTestDto, VerifiedTestDto>().ReverseMap();

            // TheoryDto, TheoryEntity
            CreateMap<TheoryDto, TheoryEntity>().ReverseMap();

            // NoIdTheoryDto, TheoryEntity
            CreateMap<NewTheoryDto, TheoryEntity>().ReverseMap();

            // NoIdTheoryDto, TheoryDto
            CreateMap<NewTheoryDto, TheoryDto>().ReverseMap();

            // TheorySectionDto, TheorySectionEntity
            CreateMap<TheorySectionDto, TheorySectionEntity>().ReverseMap();

            CreateMap<CourseSectionDto, CourseSectionEntity>().ReverseMap();

            CreateMap<NewCourseSectionDto, CourseSectionEntity>().ReverseMap();

            CreateMap<CourseSectionDto, NewCourseSectionDto>().ReverseMap();

            CreateMap<PreviewCourseSectionDto, CourseSectionDto>().ReverseMap();

            CreateMap<PreviewCourseSectionDto, CourseSectionEntity>().ReverseMap();

            CreateMap<CreateCourseDto, CourseEntity>();

            CreateMap<CourseEntity, PreviewCourseDto>();

            CreateMap<CourseEntity, PageCourseDto>();

            CreateMap<UpdateCourseDto, CourseEntity>()
                .ForMember(dest => dest.CourseSectionEntityIds, opt => opt.MapFrom(source => source.CourseSectionIds));

            CreateMap<CourseEntity, CourseDto>()
                .ForMember(dest => dest.CourseSectionIds, opt => opt.MapFrom(source => source.CourseSectionEntityIds))
                .ReverseMap();

        }


    }
}
