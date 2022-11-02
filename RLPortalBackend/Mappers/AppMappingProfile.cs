using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;

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
        }
    }
}
