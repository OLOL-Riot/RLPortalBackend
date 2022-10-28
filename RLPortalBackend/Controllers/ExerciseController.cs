using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RLPortalBackend.Entities;
using RLPortalBackend.Services;
using RLPortalBackend.Models.Exercise;

namespace RLPortalBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet("edit"), Authorize(Roles = "Administrator")]
        public async Task<ICollection<ExerciseDto>> GetAllExercisesToEdit()
        {
            return await _exerciseService.GetAsyncAllExercisesToEdit();
        }

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

        [HttpGet("solve"), Authorize(Roles = "User, Administrator")]
        public async Task<ICollection<NoRightAnswerExercise>> GetAllExercisesToSolve()
        {
            return await _exerciseService.GetAsyncAllExercisesToSolve();
        }

        [HttpGet("solve/{id:length(36)}"), Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult<NoRightAnswerExercise>> GetExerciseToSolveById(Guid id)
        {
            var exercise = await _exerciseService.GetAsyncExerciseToSolveById(id);

            if (exercise is null)
            {
                return NotFound();
            }

            return exercise;
        }

        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(NewExercise newExercise)
        {
            ExerciseDto createdExercise = await _exerciseService.CreateAsync(newExercise);

            return CreatedAtAction(nameof(GetAllExercisesToEdit), new { id = createdExercise.Id }, createdExercise);
        }


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
