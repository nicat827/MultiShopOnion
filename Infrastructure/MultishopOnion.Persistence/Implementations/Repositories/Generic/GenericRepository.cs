using MultishopOnion.Application.Abstractions.Repositories.Generic;
using MultishopOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Persistence.Implementations.Repositories.Generic
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
    }
}
