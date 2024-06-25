using ETicaret.Application.Abstractions.Token;
using ETicaret.Application.DTOs;
using ETicaret.Domen.Entitys;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateRefreshToken()
        {
            byte[] bytes = new byte[32];
            using var random=RandomNumberGenerator.Create();
            random.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        Application.DTOs.Token ITokenHandler.CreateAccessToken(AppUser appUser,DateTime expires)
        {
       
            List<Claim> claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier,appUser.Id.ToString()),
                new(ClaimTypes.Name, appUser.Name),
                
               
            };

            foreach (var item in appUser.AppUsersAppRoles)
                claims.Add(new Claim(ClaimTypes.Role,item.AppRole.Role));
         
            Application.DTOs.Token token = new();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["TokenSecurty:securityKey"]));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                expires: expires,
                notBefore: DateTime.UtcNow,
                issuer: _configuration["TokenSecurty:issuer"],
                audience: _configuration["TokenSecurty:audience"],
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                claims: claims
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return new() {
                AccessToken = tokenHandler.WriteToken(jwtSecurityToken),
                AccessTokenExpires = expires,
                RefreshToken = CreateRefreshToken(),
                RefreshTokenDateTime = expires.AddSeconds(15)
            };

        }
    }
}
