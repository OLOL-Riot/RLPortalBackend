﻿using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.VerifiedTest;
using RLPortalBackend.Repositories;
using RLPortalBackend.Repositories.Impl;

namespace RLPortalBackend.Services.Impl
{
    public class VerifiedTestService : IVerifiedTestService
    {
        private readonly IVerifiedTestRepository _verifiedTestRepository;
        private readonly IMapper _mapper;

        public VerifiedTestService(IVerifiedTestRepository verifiedTestRepository, IMapper mapper)
        {
            _verifiedTestRepository = verifiedTestRepository;
            _mapper = mapper;
        }

        public Task CreateAsync(SolvedTestDto solvedTest, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<VerifiedTestDto>> GetAsync()
        {
            ICollection<VerifiedTestEntity> verifiedTestEntities = await _verifiedTestRepository.GetAsync();
            return _mapper.Map<ICollection<VerifiedTestDto>>(verifiedTestEntities);
        }

        public async Task<VerifiedTestDto> GetByIdAsync(Guid id)
        {
            VerifiedTestEntity verifiedTestEntity = await _verifiedTestRepository.GetByIdAsync(id);
            return _mapper.Map<VerifiedTestDto>(verifiedTestEntity);
        }

        public async Task<ICollection<VerifiedTestDto>> GetByUserIdAsync(Guid userId)
        {
            ICollection<VerifiedTestEntity> verifiedTestEntities = await _verifiedTestRepository.GetByUserIdAsync(userId);
            return _mapper.Map<ICollection<VerifiedTestDto>>(verifiedTestEntities);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _verifiedTestRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, VerifiedTestDto updatedVerifiedTestDto)
        {
            VerifiedTestEntity verifiedTestEntity = _mapper.Map<VerifiedTestEntity>(updatedVerifiedTestDto);
            verifiedTestEntity.Id = id;
            await _verifiedTestRepository.UpdateAsync(id, verifiedTestEntity);
        }
    }
}
