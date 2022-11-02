using AutoMapper;
using AutoMapper.Execution;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Mappers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class NewExercisesToExerciseIdsResolver : IValueResolver<CreateTest, TestEntity, ICollection<Guid>>
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ICollection<Guid> Resolve(CreateTest source, TestEntity destination, ICollection<Guid> destMember, ResolutionContext context)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return null;
        }
    }
}
