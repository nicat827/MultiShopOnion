using MultishopOnion.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryPostDto dto, string rootPath);

        Task<IEnumerable<CategoryGetItemDto>> GetAsync(int? page = null, int? limit = null);

        Task<CategoryGetDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, CategoryPutDto dto, string rootPath);

        Task DeleteAsync(int id);
    }
}
