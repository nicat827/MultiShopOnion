using MultishopOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MultishopOnion.Application.Abstractions.Repositories.Generic
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task CreateAsync(T entity);

        Task<IEnumerable<T>> GetAsync(int? skip = null, int? limit = null, bool isTracking = false, bool iqnoreQuery = false);

    }
}
