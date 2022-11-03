using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models.Exercise;
using RLPortalBackend.Models.Test;
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
        /// Get all tests in database
        /// </summary>
        /// <returns>Collection of NoRightAnswersTest</returns>
        [HttpGet("solve"), Authorize(Roles = "User, Administrator")]
        [ProducesResponseType(typeof(ICollection<NoRightAnswersTest>), 200)]

        public async Task<ICollection<NoRightAnswersTest>> GetAllTestsToSolve()
        {
            return await _testService.GetAsyncAllTestsToSolve();
        }

        /// <summary>
        /// Get test by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoRightAnswersTest</returns>
        [HttpGet("solve/{id:length(36)}"), Authorize(Roles = "User, Administrator")]
        [ProducesResponseType(typeof(NoRightAnswersTest), 200)]
        public async Task<ActionResult<NoRightAnswersTest>> GetTestToSolveById(Guid id)
        {
            var test = await _testService.GetAsyncTestToSolveById(id);

            if (test is null)
            {
                return NotFound();
            }

            return test;
        }

        /// <summary>
        /// Get all test for edit
        /// </summary>
        /// <returns>TestDto</returns>
        [ProducesResponseType(typeof(ICollection<TestDto>), 200)]
        [HttpGet("edit"), Authorize(Roles = "Administrator")]
        public async Task<ICollection<TestDto>> GetAllTestsToEdit()
        {
            return await _testService.GetAsyncAllTestsToEdit();
        }

        /// <summary>
        /// Get test by id to edit
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
        /// Add new test in database
        /// </summary>
        /// <param name="newTest"></param>
        /// <returns>TestDto</returns>
        [ProducesResponseType(typeof(TestDto), 201)]
        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(CreateTest newTest)
        {
            TestDto createdTest = await _testService.CreateAsync(newTest);

            return CreatedAtAction(nameof(GetTestToEditById), new { id = createdTest.Id }, createdTest);
        }

        /// <summary>
        /// Verify solved test
        /// </summary>
        /// <param name="solvedTest"></param>
        /// <returns>CompletedTestResult</returns>
        [ProducesResponseType(typeof(CompletedTestResult), 200)]
        [HttpPost("verify")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<IActionResult> SendSolvedTest([FromBody] SolvedTest solvedTest)
        {

            CompletedTestResult completedTestResult = await _testService.CheckSolvedTest(solvedTest);
            return Ok(completedTestResult);
        }

        /// <summary>
        /// Update test by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedTest"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [HttpPut("{id:length(36)}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(Guid id, UpdateTest updatedTest)
        {
            var test = await _testService.GetAsyncTestToSolveById(id);

            if (test is null)
            {
                return NotFound();
            }

            await _testService.UpdateAsync(id, updatedTest);

            return NoContent();
        }

        /// <summary>
        /// Delete test by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
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
