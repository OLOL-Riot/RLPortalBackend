using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Autentification;
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

            // Exercise, NewExercise
            CreateMap<ExerciseDto, NewExerciseDto>().ReverseMap();

            // Exercise, NoRightAnswerExercise
            CreateMap<ExerciseDto, NoRightAnswerExerciseDto>().ReverseMap();

            // NewExercise, ExerciseEntity
            CreateMap<NewExerciseDto, ExerciseEntity>().ReverseMap();

            // NoRightAnswerExercise, ExerciseEntity
            CreateMap<NoRightAnswerExerciseDto, ExerciseEntity>().ReverseMap();

            // Test, TestEntity
            CreateMap<TestDto, TestEntity>().ReverseMap();

            // NoRightAnswerTest, TestEntity
            CreateMap<NoRightAnswersTestDto, TestEntity>().ReverseMap();

            // CreateTestDto, TestEntity
            CreateMap<CreateTestDto, TestEntity>().ReverseMap();

            // UpdateTestDto, TestEntity
            CreateMap<UpdateTestDto, TestEntity>().ReverseMap();

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
            CreateMap<SolvedExerciseDto, VerifiedExerciseDto>();

            // CreateVerifiedTestDto, VerifiedTestDto
            CreateMap<CreateVerifiedTestDto, VerifiedTestDto>().ReverseMap();

            // ChangeUserDataDto, User
            CreateMap<ChangeUserDataDto, UserEntity>().ReverseMap();
            
            // TheoryDto, TheoryEntity
            CreateMap<TheoryDto, TheoryEntity>().ReverseMap();

            // NoIdTheoryDto, TheoryEntity
            CreateMap<NewTheoryDto, TheoryEntity>().ReverseMap();

            // NoIdTheoryDto, TheoryDto
            CreateMap<NewTheoryDto, TheoryDto>().ReverseMap();

            // TheorySectionDto, TheorySectionEntity
            CreateMap<TheorySectionDto, TheorySectionEntity>().ReverseMap();

            CreateMap<PageCourseSectionDto, CourseSectionEntity>()
                .ForMember(dest => dest.TestEntityId, opt => opt.MapFrom(source => source.TestId))
                .ReverseMap();

            CreateMap<NewCourseSectionDto, CourseSectionEntity>().ReverseMap();

            CreateMap<PageCourseSectionDto, NewCourseSectionDto>().ReverseMap();

            CreateMap<PreviewCourseSectionDto, PageCourseSectionDto>().ReverseMap();

            CreateMap<PreviewCourseSectionDto, CourseSectionEntity>().ReverseMap();

            CreateMap<CourseSectionEntity, CourseSectionDto>()
                .ForMember(dest => dest.TestId, opt => opt.MapFrom(source => source.TestEntityId))
                .ForMember(dest => dest.TheoryId, opt => opt.MapFrom(source => source.TheoryEntityId))
                .ReverseMap();

            CreateMap<CreateCourseDto, CourseEntity>();

            CreateMap<CourseEntity, PreviewCourseDto>();

            CreateMap<CourseEntity, PageCourseDto>();

            CreateMap<UpdateCourseDto, CourseEntity>()
                .ForMember(dest => dest.CourseSectionEntityIds, opt => opt.MapFrom(source => source.CourseSectionIds));

            CreateMap<CourseEntity, CourseDto>()
                .ForMember(dest => dest.CourseSectionIds, opt => opt.MapFrom(source => source.CourseSectionEntityIds))
                .ReverseMap();

            CreateMap<UserEntity, CurrentUserDto>().ReverseMap();
        }


    }
}
