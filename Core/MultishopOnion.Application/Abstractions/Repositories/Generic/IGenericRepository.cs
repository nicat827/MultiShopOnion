using MultishopOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MultishopOnion.Application.Abstractions.Repositories.Generic
{
    internal interface IGenericRepository<T> where T : BaseEntity, new()
    {
        
    }
}
