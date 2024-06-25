using ETicaret.WebApp_.AppClasses.Abstraction;
using ETicaret.WebApp_.AppClasses.Concret;
using Microsoft.AspNetCore.Mvc;


namespace ETicaret.WebApp_.ViewComponents
{
    public class Menu:ViewComponent
    {
        readonly IJWTToken _jWTToken;
        readonly ICookieGeterated _cookieGenerated;
        readonly IConfiguration _configuration;



        public Menu(IConfiguration configuration, IJWTToken jWTToken,ICookieGeterated cookieGeterated)
        {
            _jWTToken = jWTToken;
            _cookieGenerated = cookieGeterated;
            _configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cookie = _cookieGenerated.GetCookie(_configuration["User:CookieKey"]);
            bool IsSysToken=false;
            if (cookie is not null)
             IsSysToken=await _jWTToken.IsSysToken(cookie);

            List<MenuBody> menus = new List<MenuBody>
            {
            new MenuBody{ Title="Home",Url="/Home/Index"},
            new MenuBody{ Title="Privacy",Url="/Home/Privacy"},
            new MenuBody{ Title="Baket",Url="/Home/Basket"},
               
            };
            if (IsSysToken)
            {
                menus.Add(new MenuBody { Title = "Admin panel", Url = "/admin_panel/Product2/Get" });



                menus.Add(new MenuBody { Title = "Exit", Url = "/Home/Exit" });
            }
            else
                menus.Add(new MenuBody { Title = "User log", Url = "/User/Index" });


            return View(menus);
        }
    }
    public class MenuBody
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
