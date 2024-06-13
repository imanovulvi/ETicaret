using ETicaret.Application.ModelViews;
using ETicaret.Application.Repostorys;
using ETicaret.Domen.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IAppUserReadRepostary _appUserReadRepostary;
        readonly IAppUserWriteRepostary _appUserWriteRepostary;

        public UsersController(IAppUserReadRepostary appUserReadRepostary, IAppUserWriteRepostary appUserWriteRepostary)
        {
            _appUserReadRepostary = appUserReadRepostary;
            _appUserWriteRepostary = appUserWriteRepostary;
        }

        [HttpPost]
        public async Task<IActionResult> Create(VM_AppUser_Create appUser)
        {
            bool succses=await _appUserWriteRepostary.AddAsync(appUser);
            await _appUserWriteRepostary.SaveAsync();
            if (succses)
                return Ok(new { succses = succses, message = "Creating" });
            else
                return Ok(new { succses = succses, message = "Error" });
        }
    }
}
