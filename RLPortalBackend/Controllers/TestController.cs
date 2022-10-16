using Microsoft.AspNetCore.Mvc;
using RLPortalBackend.Dto;
using RLPortalBackend.Entities;
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

        [HttpGet]
        public async Task<ICollection<TestDto>> Get()
        {
            return await _testService.GetAsync();
        }

        [HttpGet("{id:length(36)}")]
        public async Task<ActionResult<TestDto>> Get(Guid id)
        {
            var test = await _testService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            return test;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TestDto newTest)
        {
            newTest = await _testService.CreateAsync(newTest);

            return CreatedAtAction(nameof(Get), new { id = newTest.Id }, newTest);
        }

        [HttpPut("{id:length(36)}")]
        public async Task<IActionResult> Update(Guid id, TestDto updatedTest)
        {
            var test = await _testService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            updatedTest.Id = test.Id;

            await _testService.UpdateAsync(id, updatedTest);

            return NoContent();
        }

        [HttpDelete("{id:length(36)}")]
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
