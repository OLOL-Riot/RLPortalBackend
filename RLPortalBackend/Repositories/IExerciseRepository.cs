using RLPortalBackend.Entities;

namespace RLPortalBackend.Repositories
{
    /// <summary>
    /// The repository with exercises
    /// </summary>
    public interface IExerciseRepository
    {
        /// <summary>
        /// Get all exercises
        /// </summary>
        /// <returns>Collection of exercises</returns>
        public Task<ICollection<ExerciseEntity>> GetAsync();

        /// <summary>
        /// Get one exercise by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>One exercise</returns>
        public Task<ExerciseEntity> GetAsync(Guid id);

        /// <summary>
        /// Create one Exercise
        /// </summary>
        /// <param name="newExercise">New Exercise</param>
        /// <returns>
        /// </returns>
        public Task CreateAsync(ExerciseEntity newExercise);

        /// <summary>
        /// Update one Exercise by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updatedExercise">Updated Exercise</param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, ExerciseEntity updatedExercise);

        /// <summary>
        /// Remove one exercise by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);
    }
}
