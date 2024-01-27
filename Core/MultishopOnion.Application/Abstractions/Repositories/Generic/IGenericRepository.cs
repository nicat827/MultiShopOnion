using MultishopOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace MultishopOnion.Application.Abstractions.Repositories.Generic
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task CreateAsync(T entity);

        IQueryable<T> GetAsync(
            int? skip = null,
            int? limit = null,
            bool isTracking = false,
            bool iqnoreQuery = false,
            params string[] includes);

        Task<T> GetByIdAsync(
            int id,
            bool isTracking = false,
            bool iqnoreQuery = false,
            params string[] includes);

        Task<T> GetByExpressionAsync(
            Expression<Func<T, bool>> expression,
            bool isTracking = false,
            bool iqnoreQuery = false,
            params string[] includes);
        void Delete(T entity);
        void Update(T entity);
        Task<bool> IsExistsAsync(Expression<Func<T, bool>> expression);
        Task SaveChangesAsync();

    }
}
