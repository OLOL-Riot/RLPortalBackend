using AutoMapper;
using RLPortalBackend.Entities;
using RLPortalBackend.Models.Exercise;
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

        public async Task<Exercise> CreateAsync(Exercise newExercise)
        {
            ExerciseEntity newExerciseEntity = _mapper.Map<ExerciseEntity>(newExercise);
            await _exerciseRepository.CreateAsync(newExerciseEntity);
            newExercise.Id = newExerciseEntity.Id;
            return newExercise;
        }

        public async Task<ICollection<Exercise>> GetAsync()
        {
            ICollection<ExerciseEntity> exerciseEntities = await _exerciseRepository.GetAsync();
            ICollection<Exercise> exerciseDtos = _mapper.Map<ICollection<ExerciseEntity>, ICollection<Exercise>>(exerciseEntities);
            return exerciseDtos;
        }

        public async Task<Exercise> GetAsync(Guid id)
        {
            ExerciseEntity exerciseEntity = await _exerciseRepository.GetAsync(id);
            Exercise exerciseDto = _mapper.Map<Exercise>(exerciseEntity);
            return exerciseDto;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _exerciseRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(Guid id, Exercise updatedExercise)
        {
            ExerciseEntity updatedExerciseEntity = _mapper.Map<ExerciseEntity>(updatedExercise);
            await _exerciseRepository.UpdateAsync(id, updatedExerciseEntity);
        }
    }
}
