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

        Application.DTOs.Token ITokenHandler.CreateAccessToken(AppUser appUser)
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
                expires: DateTime.UtcNow.AddMinutes(10),
                notBefore: DateTime.UtcNow,
                issuer: _configuration["TokenSecurty:issuer"],
                audience: _configuration["TokenSecurty:audience"],
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                claims: claims
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);


            return token;

        }
    }
}
