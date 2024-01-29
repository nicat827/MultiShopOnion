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
    public class SizeProfile:Profile
    {
        public SizeProfile()
        {
            CreateMap<Size, SizeGetItemDto>();
            CreateMap<Size, SizeGetDto>();
            CreateMap<Size, SizePutDto>().ReverseMap();
            CreateMap<Size, SizePostDto>().ReverseMap();
        }
    }
}
