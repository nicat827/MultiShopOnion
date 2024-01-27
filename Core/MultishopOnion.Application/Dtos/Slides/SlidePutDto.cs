using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.Dtos
{
    public record SlidePutDto(string Name, string? Description, string ButtonText, int Order, IFormFile? Photo);
}
