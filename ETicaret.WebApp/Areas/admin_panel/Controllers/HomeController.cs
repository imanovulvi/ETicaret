using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebApp.Areas.admin_panel.Controllers
{
    [Area("admin_panel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
