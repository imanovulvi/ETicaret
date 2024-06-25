namespace ETicaret.WebApp_.AppClasses.Abstraction
{
    public interface IJWTToken
    {
         Task<bool> IsSysToken(string token);
    }
}
