using MultishopOnion.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.Abstractions.Services
{
    public interface IColorService
    {
        Task CreateAsync(ColorPostDto dto);

        Task<IEnumerable<ColorGetItemDto>> GetAsync(int? page = null, int? limit = null);

        Task<ColorGetDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, ColorPutDto dto);

        Task DeleteAsync(int id);
    }
}
