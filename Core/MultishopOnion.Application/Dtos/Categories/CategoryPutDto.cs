using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.Dtos
{
    public record CategoryPutDto(string Name, IFormFile? Photo);

}
