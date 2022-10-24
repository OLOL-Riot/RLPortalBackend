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
            // ExerciseDto, ExerciseEntity
            CreateMap<Exercise, ExerciseEntity>().ReverseMap();

            // TestEntity, TestDto
            CreateMap<Test, TestEntity>().ReverseMap();
        }
    }
}
