using ETicaret.Application.Repostorys;
using ETicaret.Application.UnitOfWork;
using ETicaret.Persistence.Context;
using ETicaret.Persistence.Repostorys;
using ETicaret.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaret.Persistence.Extention
{
    public static class ServiceRegistration
    {
        public static void AddServicePersistence(this IServiceCollection services,IConfiguration configuration) 
        {

            services.AddDbContext<ETicaretContext>(x => x.UseNpgsql(configuration.GetConnectionString("ETicaretPlSql")));

            services.AddScoped(typeof(IUnitOfWork), typeof(ETicaret.Persistence.UnitOfWork.UnitOfWork));

            services.AddScoped(typeof(IProductReadRepostory), typeof(ProductReadRepostory));
            services.AddScoped(typeof(IProductWriteRepostory), typeof(ProductWriteRepostory));

            services.AddScoped(typeof(IFileReadRepostory), typeof(FileReadRepostory));
            services.AddScoped(typeof(IFileWriteRepostory), typeof(FileWriteRepostory));


            services.AddScoped(typeof(IProductFileReadRepostory), typeof(ProductFileReadRepostory));
            services.AddScoped(typeof(IProductFileWriteRepostory), typeof(ProductFileWriteRepostory));


            services.AddScoped(typeof(IOrderReadRepostory), typeof(OrderReadRepostory));
            services.AddScoped(typeof(IOrderWriteRepostory), typeof(OrderWriteRepostory));


            services.AddScoped(typeof(IInvoceFileReadRepostory), typeof(InvoceFileReadRepostory));
            services.AddScoped(typeof(IInvoceFileWriteRepostory), typeof(InvoceFileWriteRepostory));


            services.AddScoped(typeof(IAppUserReadRepostary), typeof(AppUserReadRepostary));
            services.AddScoped(typeof(IAppUserWriteRepostary), typeof(AppUserWriteRepostary));


        }
    }
}
