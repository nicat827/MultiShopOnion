using MultishopOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Domain.Entities
{
    public class Category:BaseNameableEntity
    {
        public string ImageUrl { get; set; } = null!;
    }
}
