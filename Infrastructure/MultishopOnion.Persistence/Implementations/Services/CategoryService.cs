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
    internal class CategoryService:ICategoryService
    {


        private readonly ICategoryRepository _repository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IFileService fileService, IMapper mapper)
        {
            _repository = repository;
            _fileService = fileService;
            _mapper = mapper;
        }
        public async Task CreateAsync(CategoryPostDto dto, string rootPath)
        {
            _fileService.CheckFileType(dto.Photo, FileType.Image);
            _fileService.CheckFileSize(dto.Photo, 200);
            if (await _repository.IsExistsAsync(c => c.Name == dto.Name)) throw new AlreadyExsitsException("Category with this name already exsits!");
            Category newCategory = _mapper.Map<Category>(dto);
            newCategory.ImageUrl = await _fileService.CreateFileAsync(dto.Photo, rootPath, "uploads", "categories");
            await _repository.CreateAsync(newCategory);
            await _repository.SaveChangesAsync();


        }
        public async Task<IEnumerable<CategoryGetItemDto>> GetAsync(int? page = null, int? limit = null)
        {
            (int? skip, int? take) = _getSkipAndLimit(page, limit);
            IEnumerable<Category> categorys = await _repository.GetAsync(skip, take).ToListAsync();
            return _mapper.Map<IEnumerable<CategoryGetItemDto>>(categorys);

        }
        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category == null) throw new NotFoundException(mess: "Category wasnt found!");
            return _mapper.Map<CategoryGetDto>(category);

        }

        public async Task UpdateAsync(int id, CategoryPutDto dto, string rootPath)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category == null) throw new NotFoundException(mess: "Category wasnt found!");
            if (category.Name.ToLower().Trim() != dto.Name.ToLower().Trim())
                if (await _repository.IsExistsAsync(c => c.Name == dto.Name)) throw new AlreadyExsitsException("Category with this name already exsits!");
            if (dto.Photo is not null)
            {
                _fileService.CheckFileType(dto.Photo, FileType.Image);
                _fileService.CheckFileSize(dto.Photo, 200);
                _fileService.DeleteFile(category.ImageUrl, rootPath, "uploads", "categories");
                category.ImageUrl = await _fileService.CreateFileAsync(dto.Photo, rootPath, "uploads", "categories");
            }
            category = _mapper.Map(dto, category);
            _repository.Update(category);
            await _repository.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            Category? category = await _repository.GetByIdAsync(id, isTracking: true, iqnoreQuery: true);
            if (category is null) throw new NotFoundException(mess: "Category wasnt found!");
            if (category.IsDeleted) _repository.Delete(category);
            else category.IsDeleted = true;
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
