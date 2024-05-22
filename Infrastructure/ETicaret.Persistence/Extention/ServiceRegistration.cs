using ETicaret.Application.Repostorys;
using ETicaret.Persistence.Context;
using ETicaret.Persistence.Repostorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.Extention
{
    public static class ServiceRegistration
    {
        public static void AddServiceETicaret(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<ETicaretContext>(x => x.UseNpgsql(configuration.GetConnectionString("ETicaretPlSql")));
            services.AddScoped(typeof(IProductReadRepostory), typeof(ProductReadRepostory));

            services.AddScoped(typeof(IProductWriteRepostory), typeof(ProductWriteRepostory));
        }
    }
}
