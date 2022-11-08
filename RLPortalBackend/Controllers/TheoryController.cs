using Microsoft.AspNetCore.Mvc;
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
        public async Task<TheoryDto> CreateTheoryAsync([FromBody] CreateTheoryDto input)
        {
            return await _theoryService.CreateAsync(input);
        }

        [HttpGet("get-all-theories")]
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
            
            ///ПРоходить эту и другие похожие проверки в сервисе
            var theory = await _theoryService.GetByIdAsync(id);

            if (theory is null)
            {
                return NotFound();
            }

            await _theoryService.RemoveAsync(id);

            return NoContent();
        }
    }
}
