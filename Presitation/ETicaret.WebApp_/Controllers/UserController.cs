using ETicaret.Application.DTOs;
using ETicaret.Application.ModelViews;
using ETicaret.WebApp_.AppClasses;
using ETicaret.WebApp_.AppClasses.Abstraction;
using ETicaret.WebApp_.AppClasses.Concret;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebApp_.Controllers
{
    public class UserController : Controller
    {
        readonly ICookieGeterated _cookieGeterated;
        readonly IConfiguration _configuration;

     
        public UserController(ICookieGeterated cookieGeterated, IConfiguration configuration)
        {
            _configuration = configuration;
            _cookieGeterated = cookieGeterated;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Login(VM_AppUser_Login userLogin)
        {
            HttpClientService httpClientService = new(new RequestParametrs { BaseUrl = "https://localhost:7254/api", Controller = "Users", Action = "Login" });

            Token token = await httpClientService.PostAsync<VM_AppUser_Login, Token>(userLogin);
            if (token is { })
            {
                _cookieGeterated.SetCookie(_configuration["User:CookieKey"], token.AccessToken);
                _cookieGeterated.SetCookie(_configuration["User:CookieRefreshKey"], token.RefreshToken);
            }
               

            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Create(VM_AppUser_Create appUser) 
        {
            HttpClientService httpClientService = new(new RequestParametrs { BaseUrl = "https://localhost:7254/api", Controller = "Users", Action="Create" });

            Token token=await httpClientService.PostAsync<VM_AppUser_Create,Token>(appUser);

            if (token is { })
                TempData["message"] = "Creating";
            else
                TempData["message"] = "Error";

            return RedirectToAction("Index");
        }
    }
}
