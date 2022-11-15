using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RLPortalBackend.Entities;
using RLPortalBackend.Services;
using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Controllers
{
    /// <summary>
    /// Exercise controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        /// <summary>
        /// ExerciseController constructor
        /// </summary>
        /// <param name="exerciseService"></param>
        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        /// <summary>
        /// Get all exercises for editing 
        /// (Permissions: Administrator)
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<ExerciseDto>), 200)]

        [HttpGet("edit"), Authorize(Roles = "Administrator")]
        public async Task<ICollection<ExerciseDto>> GetAllExercisesToEdit()
        {
            return await _exerciseService.GetAsyncAllExercisesToEdit();
        }

        /// <summary>
        /// Get the exercise by id for editing
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ExerciseDto</returns>
        [ProducesResponseType(typeof(ExerciseDto), 200)]
        [ProducesResponseType(404)]

        [HttpGet("edit/{id:length(36)}"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ExerciseDto>> GetExerciseToEditById(Guid id)
        {
            var exercise = await _exerciseService.GetAsyncExerciseToEditById(id);

            if (exercise is null)
            {
                return NotFound();
            }

            return exercise;
        }

        /// <summary>
        /// Get all exercises for solving
        /// (Permissions: UserEntity, Administrator)
        /// </summary>
        /// <returns>Collection of NoRightAnswerExercise</returns>
        [ProducesResponseType(typeof(ICollection<NoRightAnswerExercise>), 200)]

        [HttpGet("solve"), Authorize(Roles = "UserEntity, Administrator")]
        public async Task<ICollection<NoRightAnswerExercise>> GetAllExercisesToSolve()
        {
            return await _exerciseService.GetAsyncAllExercisesToSolve();
        }

        /// <summary>
        /// Get exercise by id for solving 
        /// (Permissions: UserEntity, Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoRightAnswerExercise</returns>
        [ProducesResponseType(typeof(NoRightAnswerExercise), 200)]
        [ProducesResponseType(404)]

        [HttpGet("solve/{id:length(36)}"), Authorize(Roles = "UserEntity, Administrator")]
        public async Task<ActionResult<NoRightAnswerExercise>> GetExerciseToSolveById(Guid id)
        {
            var exercise = await _exerciseService.GetAsyncExerciseToSolveById(id);

            if (exercise is null)
            {
                return NotFound();
            }

            return exercise;
        }

        /// <summary>
        /// Create a new exercise 
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="newExercise"></param>
        /// <returns>ExerciseDto with Id</returns>
        [ProducesResponseType(typeof(ExerciseDto), 201)]

        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(NewExercise newExercise)
        {
            ExerciseDto createdExercise = await _exerciseService.CreateAsync(newExercise);

            return CreatedAtAction(nameof(GetAllExercisesToEdit), new { id = createdExercise.Id }, createdExercise);
        }

        /// <summary>
        /// Update the exercise by id 
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedExercise"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        [HttpPut("{id:length(36)}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(Guid id, NewExercise updatedExercise)
        {
            var exercise = await _exerciseService.GetAsyncExerciseToEditById(id);

            if (exercise is null)
            {
                return NotFound();
            }

            await _exerciseService.UpdateAsync(id, updatedExercise);

            return NoContent();
        }

        /// <summary>
        /// Delete Exercise by id 
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        [HttpDelete("{id:length(36)}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var exercise = await _exerciseService.GetAsyncExerciseToEditById(id);

            if (exercise is null)
            {
                return NotFound();
            }

            await _exerciseService.RemoveAsync(id);

            return NoContent();
        }

    }
}
