using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RLPortalBackend.Entities;
using RLPortalBackend.Services;
using System.Data;
using RLPortalBackend.Models.Test;

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
        public async Task<ICollection<NoRightAnswersTest>> Get()
        {
            return await _testService.GetAsync();
        }

        [HttpGet("solve/{id:length(36)}"), Authorize(Roles = "User, Administrator")]
        public async Task<ActionResult<NoRightAnswersTest>> Get(Guid id)
        {
            var test = await _testService.GetAsync(id);

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

            return CreatedAtAction(nameof(Get), new { id = createdTest.Id }, createdTest);
        }

        [HttpPut("{id:length(36)}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(Guid id, UpdateTest updatedTest)
        {
            var test = await _testService.GetAsync(id);

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
            var test = await _testService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            await _testService.RemoveAsync(id);

            return NoContent();
        }




    }
}
