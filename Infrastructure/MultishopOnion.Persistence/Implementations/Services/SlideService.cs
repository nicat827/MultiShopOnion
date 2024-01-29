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
using System.Xml;

namespace MultishopOnion.Persistence.Implementations.Services
{
    internal class SlideService : ISlideService
    {
        private readonly ISlideRepository _repository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public SlideService(ISlideRepository repository, IFileService fileService, IMapper mapper)
        {
            _repository = repository;
            _fileService = fileService;
            _mapper = mapper;
        }
        public async Task CreateAsync(SlidePostDto dto, string rootPath)
        {
            _fileService.CheckFileType(dto.Photo, FileType.Image);
            _fileService.CheckFileSize(dto.Photo, 200);
            Slide newSlide = _mapper.Map<Slide>(dto);
            newSlide.ImageUrl = await _fileService.CreateFileAsync(dto.Photo, rootPath, "uploads", "slides");
            await _repository.CreateAsync(newSlide);
            await _repository.SaveChangesAsync();

            
        }
        public async Task<IEnumerable<SlideGetItemDto>> GetAsync(int? page = null, int? limit = null)
        {
            (int? skip, int? take) = _getSkipAndLimit(page, limit); 
            IEnumerable<Slide> slides = await _repository.GetAsync(skip, take).ToListAsync();
            return _mapper.Map<IEnumerable<SlideGetItemDto>>(slides);
            
        }
        public async Task<SlideGetDto> GetByIdAsync(int id)
        {
            Slide slide = await _repository.GetByIdAsync(id);
            if (slide == null) throw new NotFoundException(mess:"Slide wasnt found!");
            return _mapper.Map<SlideGetDto>(slide);

        }

        public async Task UpdateAsync(int id, SlidePutDto dto, string rootPath)
        {
            Slide slide = await _repository.GetByIdAsync(id);
            if (slide == null) throw new NotFoundException(mess: "Slide wasnt found!");
            if (dto.Photo is not null)
            {
                _fileService.CheckFileType(dto.Photo, FileType.Image);
                _fileService.CheckFileSize(dto.Photo, 200);
                _fileService.DeleteFile(slide.ImageUrl, rootPath, "uploads", "slides");
                slide.ImageUrl = await _fileService.CreateFileAsync(dto.Photo, rootPath, "uploads", "slides");
            }
            slide = _mapper.Map(dto, slide);
            _repository.Update(slide);
            await _repository.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id, string rootPath)
        {
            Slide? slide = await _repository.GetByIdAsync(id, isTracking: true, iqnoreQuery: true);
            if (slide is null) throw new NotFoundException(mess: "Slide wasnt found!");
            if (slide.IsDeleted)
            {
                _fileService.DeleteFile(slide.ImageUrl, rootPath, "uploads", "slides");
                _repository.Delete(slide);
            }
            else slide.IsDeleted = true;
            await _repository.SaveChangesAsync();
        }
        private (int?,int?) _getSkipAndLimit(int? page, int? limit)
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
