using AutoMapper;
using RLPortalBackend.Entities;
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
            CreateMap<NoIdTheoryDto, TheoryEntity>().ReverseMap();

            // NoIdTheoryDto, TheoryDto
            CreateMap<NoIdTheoryDto, TheoryDto>().ReverseMap();

            // TheorySectionDto, TheorySectionEntity
            CreateMap<TheorySectionDto, TheorySectionEntity>().ReverseMap();

            CreateMap<CourseSectionDto, CourseSectionEntity>().ReverseMap();

            CreateMap<NewCourseSectionDto, CourseSectionEntity>().ReverseMap();

            CreateMap<CourseSectionDto, NewCourseSectionDto>().ReverseMap();

            CreateMap<PreviewCourseDto, CourseSectionDto>().ReverseMap();

            CreateMap<PreviewCourseDto, CourseSectionEntity>().ReverseMap();

        }
    }
}
