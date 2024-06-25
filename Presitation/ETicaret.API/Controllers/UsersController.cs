using ETicaret.Application.Abstractions.Token;
using ETicaret.Application.DTOs;
using ETicaret.Application.ModelViews;
using ETicaret.Application.Repostorys;
using ETicaret.Application.UnitOfWork;
using ETicaret.Domen.Entitys;
using ETicaret.Infrastructure.Services.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;


namespace ETicaret.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;


        readonly IAppUserReadRepostary _appUserReadRepostary;
        readonly IAppUserWriteRepostary _appUserWriteRepostary;
        readonly ITokenHandler _tokenHandler;



        public UsersController(IUnitOfWork unitOfWork,ITokenHandler tokenHandler,IAppUserReadRepostary appUserReadRepostary, IAppUserWriteRepostary appUserWriteRepostary)
        {
            _unitOfWork = unitOfWork;
            _tokenHandler = tokenHandler;
            _appUserReadRepostary = appUserReadRepostary;
            _appUserWriteRepostary = appUserWriteRepostary;
        }

        [HttpPost]
        public async Task<IActionResult> Create(VM_AppUser_Create userCreate)
        {
            bool succses=await _appUserWriteRepostary.AddAsync(userCreate);
            await _unitOfWork.SaveAsync();
            if (succses)
                return Ok(new { succses = succses, message = "Creating" });
            else
                return Ok(new { succses = succses, message = "Error" });
        }


        [HttpPost]
        public async Task<IActionResult> Login(VM_AppUser_Login userLogin)
        {
            AppUser? user = await _appUserReadRepostary.GetAll().Include(x=>x.AppUsersAppRoles).ThenInclude(x=>x.AppRole).FirstOrDefaultAsync(x => x.Name == userLogin.Name && x.Password == userLogin.Password);

            if (user is { })
            {
                Token token = _tokenHandler.CreateAccessToken(user, DateTime.UtcNow.AddSeconds(15));
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenDateTime = token.RefreshTokenDateTime;
                await _unitOfWork.SaveAsync();
                return Ok(token);
            }
            throw new Exception();
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            AppUser? user = await _appUserReadRepostary.GetAll().Include(x => x.AppUsersAppRoles).ThenInclude(x => x.AppRole).FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            if (user!=null &&user.RefreshTokenDateTime>DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(user, DateTime.UtcNow.AddSeconds(15));
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenDateTime = token.RefreshTokenDateTime;
                await _unitOfWork.SaveAsync();
                return Ok(token);
            }
            else
                throw new Exception();
        }


    }
}
