using ETicaret.WebApp_.AppClasses.Abstraction;

namespace ETicaret.WebApp_.AppClasses.Concret
{
    public class CookieGenerated : ICookieGeterated
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieGenerated(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetCookie(string key,string value)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddHours(1);
            option.Secure = true;
           
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value,option);
         
        }

        public void DeleteCookie(string key) 
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }

        public string GetCookie(string key)
        {
           _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(key, out string cookie);
            return cookie;
        }
    }
}
