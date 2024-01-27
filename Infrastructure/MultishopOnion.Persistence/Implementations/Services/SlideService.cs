using MultishopOnion.Application.Abstractions.Services;
using MultishopOnion.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Persistence.Implementations.Services
{
    internal class SlideService : ISlideService
    {
        public Task CreateAsync(SlidePostDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SlideGetItemDto>> GetAsync(int? page = null, int? limit = null)
        {
            throw new NotImplementedException();
        }

        public Task<SlideGetDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, SlidePutDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
