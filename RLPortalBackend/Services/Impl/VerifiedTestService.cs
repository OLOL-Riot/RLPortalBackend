using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Models.VerifiedTest;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class VerifiedTestService : IVerifiedTestService
    {
        private readonly IVerifiedTestRepository _verifiedTestRepository;
        private readonly ITestService _testService;
        private readonly IMapper _mapper;

        public VerifiedTestService(IVerifiedTestRepository verifiedTestRepository, ITestService testService, IMapper mapper)
        {
            _verifiedTestRepository = verifiedTestRepository;
            _testService = testService;
            _mapper = mapper;
        }

        public async Task CreateAsync(SolvedTestDto solvedTest, Guid userId)
        {
            // Add Exceptions Handling: test not found, incorrect exercises

            TestDto test = await _testService.GetAsyncTestToEditById(solvedTest.TestId);
            ICollection<ExerciseDto> exercises = test.Exercises;

            VerifiedTestDto verifiedTest = _mapper.Map<VerifiedTestDto>(solvedTest);

            verifiedTest.MaxPoints = exercises.Count;

            for (int i = 0; i < verifiedTest.VerifiedExercises.Count; i++)
            {
                VerifiedExerciseDto verifiedExercise = verifiedTest.VerifiedExercises.ElementAtOrDefault(i);

                var chosendAnswer = verifiedExercise.ChosenAnswer;

                verifiedExercise.IsRight = (chosendAnswer == exercises.ElementAtOrDefault(i).RightAnswer);
            }

            verifiedTest.Points = verifiedTest.VerifiedExercises.Count(verifiedExercise => verifiedExercise.IsRight);

            VerifiedTestEntity verifiedTestEntity = _mapper.Map<VerifiedTestEntity>(verifiedTest);
            await _verifiedTestRepository.CreateAsync(verifiedTestEntity);

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
