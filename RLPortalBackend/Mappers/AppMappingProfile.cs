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
            CreateMap<Exercise, ExerciseEntity>().ReverseMap();

            // NewExercise, ExerciseEntity
            CreateMap<NewExercise, ExerciseEntity>().ReverseMap();

            // Test, TestEntity
            CreateMap<Test, TestEntity>().ReverseMap();

            // NewTest, TestEntity
            CreateMap<NewTest, TestEntity>().ReverseMap();
        }
    }
}
