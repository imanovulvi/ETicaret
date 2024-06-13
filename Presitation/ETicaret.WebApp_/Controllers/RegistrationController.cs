using ETicaret.Application.ModelViews;
using ETicaret.WebApp_.AppClasses;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebApp_.Controllers
{
    public class RegistrationController : Controller
    {
        HttpClientService httpClientService = new(new RequestParametrs { BaseUrl = "https://localhost:7254/api", Controller = "Users" });
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create(VM_AppUser_Create appUser) 
        {
           bool succes=await httpClientService.PostAsync<VM_AppUser_Create>(appUser);
            
            if (succes)
               TempData["message"] = "Creating";
            else
                TempData["message"] = "Error";
            
            return Redirect("/Registration/Index");
        }
    }
}
