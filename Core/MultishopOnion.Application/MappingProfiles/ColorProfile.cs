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
    public class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorGetItemDto>();
            CreateMap<Color, ColorGetDto>();
            CreateMap<Color, ColorPutDto>().ReverseMap();
            CreateMap<Color, ColorPostDto>().ReverseMap();
        }
    }
}
