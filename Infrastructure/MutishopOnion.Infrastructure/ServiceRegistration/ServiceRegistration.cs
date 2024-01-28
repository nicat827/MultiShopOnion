using Microsoft.Extensions.DependencyInjection;
using MultishopOnion.Application.Abstractions.Services;
using MutishopOnion.Infrastructure.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MutishopOnion.Infrastructure.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services) 
        {
            services.AddScoped<IFileService, FileService>();
        }
    }
}
