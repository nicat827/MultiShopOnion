using MultishopOnion.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.Abstractions.Services
{
    public interface IColorSexrvice
    {
        Task CreateAsync(ColorPostDto dto);

        Task<IEnumerable<SizeGetItemDto>> GetAsync(int? page = null, int? limit = null);

        Task<SizeGetDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, ColorPutDto dto);

        Task DeleteAsync(int id);
    }
}
