using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using RLPortalBackend.Models.Theory;
using RLPortalBackend.Services;
using RLPortalBackend.Services.Impl;

namespace RLPortalBackend.Controllers
{
    /// <summary>
    /// TheoryController
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TheoryController : ControllerBase
    {
        private readonly ITheoryService _theoryService;

        public TheoryController(ITheoryService theoryService)
        {
            _theoryService = theoryService;
        }

        /// <summary>
        /// Create Theory
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TheoryDto), 201)]

        [Authorize(Roles = "Administrator")]
        [HttpPost("create")]
        public async Task<ActionResult<TheoryDto>> CreateTheoryAsync([FromBody] NoIdTheoryDto input)
        {
            TheoryDto dto = await _theoryService.CreateAsync(input);

            return CreatedAtAction(nameof(CreateTheoryAsync) ,dto);
        }

        /// <summary>
        /// Get all Theory
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<TheoryDto>), 200)]

        [Authorize(Roles = "User, Administrator")]
        [HttpGet("get")]
        public async Task<ICollection<TheoryDto>> GetTheoriesAsync()
        {
            return await _theoryService.GetAsync();
        }

        /// <summary>
        /// Get Theory by Id
        /// (Permissions: User, Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TheoryDto),200)]
        [ProducesResponseType(404)]

        [Authorize(Roles = "User, Administrator")]
        [HttpGet("get/{id:length(36)}")]
        public async Task<TheoryDto> GetById(Guid id)
        {
            ///Добавить проверку на наличие теории в бд внутри сервиса
            return await _theoryService.GetByIdAsync(id);
        }

        /// <summary>
        /// Remove Theory by Id
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        [Authorize(Roles = "Administrator")]
        [HttpDelete("remove/{id:length(36)}")]
        public async Task<ActionResult> DeleteById(Guid id)
        {
            await _theoryService.RemoveAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Update Theory by Id
        /// (Permissions: Administrator)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        [Authorize(Roles = "Administrator")]
        [HttpPut("update/{id:length(36)}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] NoIdTheoryDto update)
        {
            await _theoryService.UpdateAsync(id, update);
            return NoContent();
        }
    }
}
