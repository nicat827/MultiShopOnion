using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultishopOnion.Application.Abstractions.Repositories;
using MultishopOnion.Application.Abstractions.Services;
using MultishopOnion.Application.Dtos;
using MultishopOnion.Application.Exceptions;
using MultishopOnion.Domain.Entities;
using MultishopOnion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Persistence.Implementations.Services
{
    internal class ColorService:IColorService
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(ColorPostDto dto)
        {
            if (await _repository.IsExistsAsync(c => c.Name == dto.Name)) throw new AlreadyExsitsException("Color with this name already exsits!");
            Color newColor = _mapper.Map<Color>(dto);
            await _repository.CreateAsync(newColor);
            await _repository.SaveChangesAsync();


        }
        public async Task<IEnumerable<ColorGetItemDto>> GetAsync(int? page = null, int? limit = null)
        {
            (int? skip, int? take) = _getSkipAndLimit(page, limit);
            IEnumerable<Color> colors = await _repository.GetAsync(skip, take).ToListAsync();
            return _mapper.Map<IEnumerable<ColorGetItemDto>>(colors);

        }
        public async Task<ColorGetDto> GetByIdAsync(int id)
        {
            Color color = await _repository.GetByIdAsync(id);
            if (color == null) throw new NotFoundException(mess: "Color wasnt found!");
            return _mapper.Map<ColorGetDto>(color);

        }

        public async Task UpdateAsync(int id, ColorPutDto dto)
        {
            Color color = await _repository.GetByIdAsync(id);
            if (color == null) throw new NotFoundException(mess: "Color wasnt found!");

            if (color.Name.Trim().ToLower() != dto.Name.ToLower().Trim())
                if (await _repository.IsExistsAsync(c => c.Name == dto.Name)) throw new AlreadyExsitsException("Color with this name already exsits!");

            color = _mapper.Map(dto, color);
            _repository.Update(color);
            await _repository.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            Color? color = await _repository.GetByIdAsync(id, isTracking: true, iqnoreQuery: true);
            if (color is null) throw new NotFoundException(mess: "Color wasnt found!");
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
