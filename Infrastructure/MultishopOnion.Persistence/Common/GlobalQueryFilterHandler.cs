using Microsoft.EntityFrameworkCore;
using MultishopOnion.Domain.Entities;
using MultishopOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Persistence.Common
{
    internal static class GlobalQueryFilterHandler
    {
        public static void ApplyQueryFilters(this ModelBuilder builder)
        {
            builder.ApplyQueryFilter<Slide>();
        }

        private static void ApplyQueryFilter<TEntity>(this ModelBuilder builder) where TEntity : BaseEntity, new() 
        {
            builder.Entity<TEntity>().HasQueryFilter(e => e.IsDeleted == false);
        }


    }
}
