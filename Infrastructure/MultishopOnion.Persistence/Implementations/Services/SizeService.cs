using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultishopOnion.Application.Abstractions.Repositories;
using MultishopOnion.Application.Abstractions.Services;
using MultishopOnion.Application.Dtos;
using MultishopOnion.Application.Exceptions;
using MultishopOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Persistence.Implementations.Services
{
    internal class SizeService:ISizeService
    {

        private readonly ISizeRepository _repository;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(SizePostDto dto)
        {
            if (await _repository.IsExistsAsync(c => c.Name == dto.Name)) throw new AlreadyExsitsException("Size with this name already exsits!");
            Size newSize = _mapper.Map<Size>(dto);
            await _repository.CreateAsync(newSize);
            await _repository.SaveChangesAsync();


        }
        public async Task<IEnumerable<SizeGetItemDto>> GetAsync(int? page = null, int? limit = null)
        {
            (int? skip, int? take) = _getSkipAndLimit(page, limit);
            IEnumerable<Size> colors = await _repository.GetAsync(skip, take).ToListAsync();
            return _mapper.Map<IEnumerable<SizeGetItemDto>>(colors);

        }
        public async Task<SizeGetDto> GetByIdAsync(int id)
        {
            Size color = await _repository.GetByIdAsync(id);
            if (color == null) throw new NotFoundException(mess: "Size wasnt found!");
            return _mapper.Map<SizeGetDto>(color);

        }

        public async Task UpdateAsync(int id, SizePutDto dto)
        {
            Size color = await _repository.GetByIdAsync(id);
            if (color == null) throw new NotFoundException(mess: "Size wasnt found!");

            if (color.Name.Trim().ToLower() != dto.Name.ToLower().Trim())
                if (await _repository.IsExistsAsync(c => c.Name == dto.Name)) throw new AlreadyExsitsException("Size with this name already exsits!");

            color = _mapper.Map(dto, color);
            _repository.Update(color);
            await _repository.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            Size? color = await _repository.GetByIdAsync(id, isTracking: true, iqnoreQuery: true);
            if (color is null) throw new NotFoundException(mess: "Size wasnt found!");
            if (color.IsDeleted) _repository.Delete(color);
            else color.IsDeleted = true;
            await _repository.SaveChangesAsync();
        }
        private (int?, int?) _getSkipAndLimit(int? page, int? limit)
        {
            int? skip = null;
            if (page is not null)
            {
                if (limit is null) limit = 10;
                skip = (page - 1) * limit;

            }
            return (skip, limit);
        }
    }
}
