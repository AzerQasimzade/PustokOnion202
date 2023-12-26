using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion202.Application.Dtos;

using PustokOnion202.Application.Interfaces.Services;

namespace PustokOnion202.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _service;

        public TagsController(ITagService service)
        {
            _service = service;
        }
        [HttpGet]

        public async Task<IActionResult> Get(int page = 1, int take = 5)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateTagDto tagDto)
        {
            await _service.Create(tagDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateTagDto updateTagDto)
        {
            await _service.Update(id, updateTagDto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
