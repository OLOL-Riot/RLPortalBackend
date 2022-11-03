using RLPortalBackend.Entities;
using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Services
{
    /// <summary>
    /// Service for exercise
    /// </summary>
    public interface IExerciseService
    {
        /// <summary>
        /// Get all exercises to edit
        /// </summary>
        /// <returns>Collection of <see cref="ExerciseDto"/></returns>
        public Task<ICollection<ExerciseDto>> GetAsyncAllExercisesToEdit();

        /// <summary>
        /// Get one exercise to edit by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns><see cref="ExerciseDto"/></returns>
        public Task<ExerciseDto> GetAsyncExerciseToEditById(Guid id);

        /// <summary>
        /// Get all exercises to edit
        /// </summary>
        /// <returns>Collection of <see cref="ExerciseDto"/></returns>
        public Task<ICollection<NoRightAnswerExercise>> GetAsyncAllExercisesToSolve();

        /// <summary>
        /// Get one exercise to edit by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns><see cref="NoRightAnswerExercise"/></returns>
        public Task<NoRightAnswerExercise> GetAsyncExerciseToSolveById(Guid id);

        /// <summary>
        /// Create one exerci9se
        /// </summary>
        /// <param name="newExercise">New exercise</param>
        /// <returns><see cref="ExerciseDto"/></returns>
        public Task<ExerciseDto> CreateAsync(NewExercise newExercise);

        /// <summary>
        /// Update one exercise by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updatedExercise">Updated Exercise</param>
        /// <returns></returns>
        public Task UpdateAsync(Guid id, NewExercise updatedExercise);

        /// <summary>
        /// Remove one exercise
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);
    }
}
