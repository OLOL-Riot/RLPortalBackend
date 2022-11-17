using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Models.VerifiedTest;
using RLPortalBackend.Services;

namespace RLPortalBackend.Controllers
{
    /// <summary>
    /// TestController
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        /// <summary>
        /// TestController constructor
        /// </summary>
        /// <param name="testService"></param>
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        /// <summary>
        /// Get all tests for solving 
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <returns>Collection of NoRightAnswersTestDto</returns>
        [ProducesResponseType(typeof(ICollection<NoRightAnswersTestDto>), 200)]

        [HttpGet("solve"), Authorize(Roles = "User, Administrator")]
        public async Task<ICollection<NoRightAnswersTestDto>> GetAllTestsToSolve()
        {
            return await _testService.GetAsyncAllTestsToSolve();
        }

        /// <summary>
        /// Get the test by Id for solving
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoRightAnswersTestDto</returns>
        [ProducesResponseType(typeof(NoRightAnswersTestDto), 200)]
        [ProducesResponseType(404)]

        [HttpGet("solve/{id:length(36)}"), Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult<NoRightAnswersTestDto>> GetTestToSolveById(Guid id)
        {
            var test = await _testService.GetAsyncTestToSolveById(id);

            if (test is null)
            {
                return NotFound();
            }

            return test;
        }

        /// <summary>
        /// Get all tests for editing 
        /// (Permissions: Administrator)
        /// </summary>
        /// <returns>TestDto</returns>
        [ProducesResponseType(typeof(ICollection<TestDto>), 200)]

        [HttpGet("edit"), Authorize(Roles = "Administrator")]
        public async Task<ICollection<TestDto>> GetAllTestsToEdit()
        {
            return await _testService.GetAsyncAllTestsToEdit();
        }

        /// <summary>
        /// Get the test by id for editing 
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>TestDto</returns>
        [ProducesResponseType(typeof(TestDto), 200)]

        [HttpGet("edit/{id:length(36)}"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult<TestDto>> GetTestToEditById(Guid id)
        {
            var test = await _testService.GetAsyncTestToEditById(id);

            if (test is null)
            {
                return NotFound();
            }

            return test;
        }

        /// <summary>
        /// Create a new test 
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="newTest"></param>
        /// <returns>TestDto</returns>
        [ProducesResponseType(typeof(TestDto), 201)]

        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(CreateTestDto newTest)
        {
            TestDto createdTest = await _testService.CreateAsync(newTest);

            return CreatedAtAction(nameof(GetTestToEditById), new { id = createdTest.Id }, createdTest);
        }

        /// <summary>
        /// Update the test by id 
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedTest"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        [HttpPut("{id:length(36)}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(Guid id, UpdateTestDto updatedTest)
        {
            var test = await _testService.GetAsyncTestToSolveById(id);
            await _testService.UpdateAsync(id, updatedTest);
            return NoContent();
        }

        /// <summary>
        /// Delete the test by id 
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        [HttpDelete("{id:length(36)}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var test = await _testService.GetAsyncTestToSolveById(id);

            if (test is null)
            {
                return NotFound();
            }

            await _testService.RemoveAsync(id);

            return NoContent();
        }






    }
}
