using AutoMapper;
using RLPortalBackend.Dto;
using RLPortalBackend.Entities;
using RLPortalBackend.Repositories;

namespace RLPortalBackend.Services.Impl
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(ExerciseEntity newExercise)
        {
            await _exerciseRepository.CreateAsync(newExercise);
        }

        public async Task<ICollection<ExerciseDto>> GetAsync()
        {
            ICollection<ExerciseEntity> exerciseEntities = await _exerciseRepository.GetAsync();
            ICollection<ExerciseDto> exerciseDtos = _mapper.Map<ICollection<ExerciseEntity>, ICollection<ExerciseDto>>(exerciseEntities);
            return exerciseDtos;
        }

        public async Task<ExerciseEntity> GetAsync(Guid id)
        {
            return await _exerciseRepository.GetAsync(id);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _exerciseRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, ExerciseEntity updatedExercise)
        {
            await _exerciseRepository.UpdateAsync(id, updatedExercise);
        }
    }
}
