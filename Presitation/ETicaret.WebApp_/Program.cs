using ETicaret.WebApp_.AppClasses.Extentions;
using System.Threading.RateLimiting;

namespace ETicaret.WebApp_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
           builder.Services.AddHttpContextAccessor();
            builder.Services.AddServices();

            var app = builder.Build();
  
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
               name: "defaultWithArea",
               pattern: "{area=admin_panel}/{controller=Home}/{action=Index}/{id?}/{id2?}");

            app.Run();
        }
    }
}
