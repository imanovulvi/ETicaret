using ETicaret.Infrastructure.Extentions;
using ETicaret.Persistence.Extention;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace ETicaret.API
{
    //https://github.com/enesozmus/Shopizer/blob/master/api/WebAPI/Controllers/ProductsController.cs
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddServicePersistence(builder.Configuration);
            builder.Services.AddServiceInfrastructure();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters() { 
                ValidateAudience = true,//Hansi sayt istifade edecek
                ValidateIssuer = true,//Hansi data baylayazaq yeni api
                ValidateLifetime= true,//token zamanai
                ValidateIssuerSigningKey = true,//tokene uygun bir key deyer
                ValidIssuer = builder.Configuration["TokenSecurty:issuer"],
                    ValidAudience = builder.Configuration["TokenSecurty:audience"],
                 IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenSecurty:securityKey"]))
                 


                };
            
            
            });
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
         
            app.MapControllers();

            app.Run();
        }
    }
}
