using ETicaret.WebApp_.AppClasses.Abstraction;
using ETicaret.WebApp_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETicaret.WebApp_.Controllers
{
    public class HomeController : Controller
    {
        readonly ICookieGeterated _cookieGeterated;
        readonly IConfiguration _configuration;
        public HomeController(ICookieGeterated cookieGeterated, IConfiguration configuration)
        {
            _configuration = configuration;
            _cookieGeterated = cookieGeterated;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Exit()
        {
            _cookieGeterated.DeleteCookie(_configuration["User:CookieKey"]);
            return Redirect("/Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
