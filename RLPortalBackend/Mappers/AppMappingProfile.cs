using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;

namespace RLPortalBackend.Mappers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
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
