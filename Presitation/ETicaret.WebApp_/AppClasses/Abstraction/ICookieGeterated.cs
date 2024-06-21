namespace ETicaret.WebApp_.AppClasses.Abstraction
{
    public interface ICookieGeterated
    {
        void SetCookie(string key, string value);
        void DeleteCookie(string key);
        string GetCookie(string key);
    }
}
