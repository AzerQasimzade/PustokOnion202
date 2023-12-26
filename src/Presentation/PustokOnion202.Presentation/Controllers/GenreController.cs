using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion202.Application.Dtos;
using PustokOnion202.Application.DTOs.Genre;
using PustokOnion202.Application.Interfaces.Services;

namespace PustokOnion202.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService service)
        {
            _service = service;
        }
        [HttpGet]

        public async Task<IActionResult> Get(int page = 1, int take = 5)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateGenreDto genreDto)
        {
            await _service.Create(genreDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateGenreDto updateGenreDto)
        {
            await _service.Update(id, updateGenreDto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
