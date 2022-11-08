using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using RLPortalBackend.Models.Theory;
using RLPortalBackend.Services;
using RLPortalBackend.Services.Impl;

namespace RLPortalBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TheoryController : ControllerBase
    {
        private readonly ITheoryService _theoryService;

        public TheoryController(ITheoryService theoryService)
        {
            _theoryService = theoryService;
        }


        [HttpPost("create")]
        public async Task<ActionResult<TheoryDto>> CreateTheoryAsync([FromBody] NoIdTheoryDto input)
        {
            TheoryDto dto = await _theoryService.CreateAsync(input);

            return CreatedAtAction(nameof(CreateTheoryAsync) ,dto);
        }

        [HttpGet("get")]
        public async Task<ICollection<TheoryDto>> GetTheoriesAsync()
        {
            return await _theoryService.GetAsync();
        }

        [HttpGet("get/{id:length(36)}")]
        public async Task<TheoryDto> GetById(Guid id)
        {
            ///Добавить проверку на наличие теории в бд внутри сервиса
            return await _theoryService.GetByIdAsync(id);
        }

        [HttpDelete("remove/{id:length(36)}")]
        public async Task<ActionResult> DeleteById(Guid id)
        {
            await _theoryService.RemoveAsync(id);
            return NoContent();
        }

        [HttpPut("update/{id:length(36)}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] NoIdTheoryDto update)
        {
            await _theoryService.UpdateAsync(id, update);
            return NoContent();
        }
    }
}
