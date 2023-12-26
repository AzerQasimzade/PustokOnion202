using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PustokOnion202.Application.DTOs.Genre;
using PustokOnion202.Application.Interfaces.Services;

namespace PustokOnion202.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorsController(IAuthorService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 5)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateAuthorDto authorDto)
        {
            await _service.Create(authorDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateAuthorDto updateAuthorDto)
        {
            await _service.Update(id, updateAuthorDto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
