using AutoMapper;
using RLPortalBackend.Dto;
using RLPortalBackend.Entities;
using System;

namespace RLPortalBackend.Mappers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<ExerciseDto, ExerciseEntity>().ReverseMap();//.IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
