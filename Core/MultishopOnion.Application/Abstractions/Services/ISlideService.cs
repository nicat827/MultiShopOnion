using MultishopOnion.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.Abstractions.Services
{
    public interface ISlideService
    {

        Task CreateAsync(SlidePostDto dto, string rootPath);

        Task<IEnumerable<SlideGetItemDto>> GetAsync(int? page = null, int? limit = null);

        Task<SlideGetDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, SlidePutDto dto, string rootPath);

        Task DeleteAsync(int id,string rootPath);
    }
}
