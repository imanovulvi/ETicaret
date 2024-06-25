using ETicaret.WebApp_.AppClasses.Abstraction;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ETicaret.WebApp_.AppClasses.Concret
{
    public class JWTToken : IJWTToken
    {
   
        readonly IConfiguration _configuration;



        public JWTToken(IConfiguration configuration)
        {
            _configuration = configuration;
         

        }
        public async Task<bool> IsSysToken(string token)
        {

    
            JwtSecurityTokenHandler jwtSecurityToken = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["TokenSecurty:securityKey"]);
            TokenValidationResult result = await jwtSecurityToken.ValidateTokenAsync(token, new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidAudience = _configuration["TokenSecurty:audience"],
                ValidIssuer = _configuration["TokenSecurty:issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            });
            return result.IsValid;
        }
    }
}
