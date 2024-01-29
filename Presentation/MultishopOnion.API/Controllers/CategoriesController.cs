using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultishopOnion.Application.Abstractions.Services;
using MultishopOnion.Application.Dtos;
using MultishopOnion.Application.Exceptions;

namespace MultishopOnion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IWebHostEnvironment _env;

        public CategoriesController(ICategoryService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }
        [HttpPost]

        public async Task<IActionResult> Post([FromForm] CategoryPostDto dto)
        {
            await _service.CreateAsync(dto, _env.WebRootPath);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? page = null, int? limit = null)
        {
            if (page <= 0 || limit <= 0) throw new BadRequestException(mess: "Invalid page or limit!");
            return Ok(await _service.GetAsync(page, limit));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) throw new BadRequestException(mess: "Invalid id!");
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] CategoryPutDto dto)
        {
            if (id <= 0) throw new BadRequestException(mess: "Invalid id!");
            await _service.UpdateAsync(id, dto, _env.WebRootPath);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) throw new BadRequestException(mess: "Invalid id!");
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
