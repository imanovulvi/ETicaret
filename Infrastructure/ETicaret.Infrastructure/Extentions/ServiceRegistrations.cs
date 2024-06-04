using ETicaret.Application.Services;
using ETicaret.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Infrastructure.Extentions
{
    public static class ServiceRegistrations
    {
        public static void AddServiceInfrastructure(this IServiceCollection service) 
        {
            service.AddScoped(typeof(IFileService), typeof(FileService));
        }
    }
}
