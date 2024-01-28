using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultishopOnion.Application.Abstractions.Repositories;
using MultishopOnion.Application.Abstractions.Services;
using MultishopOnion.Persistence.DAL;
using MultishopOnion.Persistence.Implementations.Repositories;
using MultishopOnion.Persistence.Implementations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));

            //repos
            services.AddScoped<ISlideRepository, SlideRepository>();

            //services
            services.AddScoped<ISlideService, SlideService>();
        }
    }
}
