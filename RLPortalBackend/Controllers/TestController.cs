using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Models.Test;
using RLPortalBackend.Services;

namespace RLPortalBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("solve"), Authorize(Roles = "User, Administrator")]
        public async Task<ICollection<NoRightAnswersTest>> GetAllTestsToSolve()
        {
            return await _testService.GetAsyncAllTestsToSolve();
        }

        [HttpGet("solve/{id:length(36)}"), Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult<NoRightAnswersTest>> GetTestToSolveById(Guid id)
        {
            var test = await _testService.GetAsyncTestToSolveById(id);

            if (test is null)
            {
                return NotFound();
            }

            return test;
        }

        [HttpGet("edit"), Authorize(Roles = "Administrator")]
        public async Task<ICollection<TestDto>> GetAllTestsToEdit()
        {
            return await _testService.GetAsyncAllTestsToEdit();
        }

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


        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Post(CreateTest newTest)
        {
            TestDto createdTest = await _testService.CreateAsync(newTest);

            return CreatedAtAction(nameof(GetTestToEditById), new { id = createdTest.Id }, createdTest);
        }

        [HttpPost("check")]
        [Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult<CompletedTestResult>> SendSolvedTest([FromBody] SolvedTest solvedTest)
        {
            CompletedTestResult completedTestResult = await _testService.CheckSolvedTest(solvedTest);
            return completedTestResult;
        }

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
