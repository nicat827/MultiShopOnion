using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Application.Dtos
{
    public record SlideGetDto(int Id, string Name, string? Description, string ButtonText, string ImageUrl);
    
}
