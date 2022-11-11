using AutoMapper;
using AutoMapper.Execution;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Mappers
{
#pragma warning disable CS1591
    public class NewExercisesToExerciseIdsResolver : IValueResolver<CreateTest, TestEntity, ICollection<Guid>>
    {
        public ICollection<Guid> Resolve(CreateTest source, TestEntity destination, ICollection<Guid> destMember, ResolutionContext context)
        {
            return null;
        }
    }
}
