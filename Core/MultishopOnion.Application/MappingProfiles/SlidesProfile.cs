using AutoMapper;
using MultishopOnion.Application.Dtos;
using MultishopOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.MappingProfiles
{
    internal class SlidesProfile:Profile
    {
        public SlidesProfile()
        {
            CreateMap<Slide, SlideGetItemDto>();
            CreateMap<Slide, SlideGetDto>();
            CreateMap<Slide, SlidePutDto>().ReverseMap();
            CreateMap<Slide, SlidePostDto>().ReverseMap();
        }
    }
}
