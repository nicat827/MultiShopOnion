using AutoMapper;
using MultishopOnion.Application.Dtos;
using MultishopOnion.Domain.Entities;


namespace MultishopOnion.Application.MappingProfiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetItemDto>();
            CreateMap<Category, CategoryGetDto>();
            CreateMap<Category, CategoryPutDto>().ReverseMap();
            CreateMap<Category, CategoryPostDto>().ReverseMap();
        }
    }
}
