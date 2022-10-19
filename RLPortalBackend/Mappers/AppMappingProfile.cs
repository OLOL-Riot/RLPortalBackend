using AutoMapper;
using RLPortalBackend.Dto;
using RLPortalBackend.Entities;

namespace RLPortalBackend.Mappers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            // ExerciseDto, ExerciseEntity
            CreateMap<ExerciseDto, ExerciseEntity>().ReverseMap();

            // TestEntity, TestDto
            CreateMap<TestDto, TestEntity>().ReverseMap();
        }
    }
}
