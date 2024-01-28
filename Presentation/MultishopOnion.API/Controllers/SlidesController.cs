using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using MultishopOnion.Application.Abstractions.Services;
using MultishopOnion.Application.Dtos;
using System.Net;

namespace MultishopOnion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidesController : ControllerBase
    {
        private readonly ISlideService _service;
        private readonly IWebHostEnvironment _env;

        public SlidesController(ISlideService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }
        [HttpPost]

        public async Task<IActionResult> Post([FromForm]SlidePostDto dto)
        {
            await _service.CreateAsync(dto, _env.WebRootPath);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? page = null, int? limit = null)
        {
            if (page <= 0 || limit <= 0) return BadRequest();
            return Ok(await  _service.GetAsync(page, limit));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id<=0) return NotFound();
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] SlidePutDto dto)
        {
            if (id <= 0) return BadRequest();
            await _service.UpdateAsync(id,dto, _env.WebRootPath);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }


    }
}
