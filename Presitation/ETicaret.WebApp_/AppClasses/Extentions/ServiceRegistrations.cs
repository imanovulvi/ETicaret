using ETicaret.WebApp_.AppClasses.Abstraction;
using ETicaret.WebApp_.AppClasses.Concret;

namespace ETicaret.WebApp_.AppClasses.Extentions
{
    public static class ServiceRegistrations
    {
        public static void AddServices(this IServiceCollection services)
        {  
            services.AddScoped(typeof(IJWTToken), typeof(JWTToken));
            services.AddScoped(typeof(ICookieGeterated), typeof(CookieGenerated));
         
        }
    }
}
