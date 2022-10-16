using Microsoft.AspNetCore.Mvc;
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
        public async Task<ICollection<TestEntity>> Get()
        {
            return await _testService.GetAsync();
        }

        [HttpGet("{id:length(36)}")]
        public async Task<ActionResult<TestEntity>> Get(Guid id)
        {
            var test = await _testService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            return test;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TestEntity newTest)
        {
            await _testService.CreateAsync(newTest);

            return CreatedAtAction(nameof(Get), new { id = newTest.Id }, newTest);
        }

        [HttpPut("{id:length(36)}")]
        public async Task<IActionResult> Update(Guid id, TestEntity updatedTest)
        {
            var test = await _testService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            updatedTest.Id = test.Id;

            await _testService.UpdateAsync(id, test);

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
