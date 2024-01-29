using Microsoft.AspNetCore.Mvc;
using MultishopOnion.Application.Abstractions.Services;
using MultishopOnion.Application.Dtos;
using MultishopOnion.Application.Exceptions;

namespace MultishopOnion.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ColorsController:ControllerBase
    {
        private readonly IColorService _service;

        public ColorsController(IColorService service)
        {
            _service = service;
        }
        [HttpPost]

        public async Task<IActionResult> Post([FromForm] ColorPostDto dto)
        {
            await _service.CreateAsync(dto);
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
        public async Task<IActionResult> Put(int id, [FromForm] ColorPutDto dto)
        {
            if (id <= 0) throw new BadRequestException(mess: "Invalid id!");
            await _service.UpdateAsync(id, dto);
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
