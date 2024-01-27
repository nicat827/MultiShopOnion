using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MultishopOnion.Application.Abstractions.Repositories.Generic;
using MultishopOnion.Domain.Entities.Base;
using MultishopOnion.Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Persistence.Implementations.Repositories.Generic
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public IQueryable<T> GetAsync(int? skip = null, int? limit = null, bool isTracking = false, bool iqnoreQuery = false, params string[] includes)
        {
            IQueryable<T> query = _table;
            if (iqnoreQuery) query = query.IgnoreQueryFilters();
            if (skip is not null) query = query.Skip((int) skip);
            if (limit is not null) query = query.Take((int)limit);
            query = _applyIncludes(query, includes);
            return isTracking ? query : query.AsNoTracking();
            

        }
        public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = false, bool iqnoreQuery = false, params string[] includes)
        {

            IQueryable<T> query = _table;
            if (iqnoreQuery) query = query.IgnoreQueryFilters();
            query = query.Where(expression);
            query = _applyIncludes(query, includes);
            return isTracking ? await query.FirstOrDefaultAsync() : await  query.AsNoTracking().FirstOrDefaultAsync();


        }

        public async Task<T> GetByIdAsync(int id, bool isTracking = false, bool iqnoreQuery = false, params string[] includes)
        {
            IQueryable<T> query = _table;
            if (iqnoreQuery) query = query.IgnoreQueryFilters();
            query = query.Where(e => e.Id == id);
            query = _applyIncludes(query, includes);
            return isTracking ? await query.FirstOrDefaultAsync() : await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Update(T entity)
        {
            _table.Update(entity);
        }
        private static IQueryable<T> _applyIncludes(IQueryable<T> query, params string[] includes)
        {
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
    }
}
