using Microsoft.EntityFrameworkCore;
using MultishopOnion.Domain.Entities;
using MultishopOnion.Domain.Entities.Base;
using MultishopOnion.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Persistence.DAL
{
    internal class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt) { }
       
        public DbSet<Slide> Slides { get; set; }

        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyQueryFilters();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in entities)
            {
                switch (data.State) 
                {
                    case EntityState.Added:
                        data.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        data.Entity.LastUpdatedAt = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
