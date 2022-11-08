using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Theory;

namespace RLPortalBackend.Mappers
{
#pragma warning disable CS1591
    public class CreateTheorySectionToTheorySectionIdsResolver : IValueResolver<CreateTheorySectionDto, TheorySectionEntity, ICollection<Guid>>
    {
        public ICollection<Guid> Resolve(CreateTheorySectionDto source, TheorySectionEntity destination, ICollection<Guid> destMember, ResolutionContext context)
        {
            return null;
        }
    }
}
