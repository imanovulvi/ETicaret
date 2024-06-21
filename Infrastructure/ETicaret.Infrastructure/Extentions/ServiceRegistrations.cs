using ETicaret.Application.Abstractions.Storage;
using ETicaret.Application.Abstractions.Storage.Local;
using ETicaret.Application.Abstractions.Token;
using ETicaret.Infrastructure.Services;
using ETicaret.Infrastructure.Services.Storage.Local;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.Infrastructure.Services.Token;

namespace ETicaret.Infrastructure.Extentions
{
    public static class ServiceRegistrations
    {
        public static void AddServiceInfrastructure(this IServiceCollection service) 
        {
            
            service.AddScoped<IStorage, LocalStorage>();
            service.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
