using ETicaret.Application.Repostorys;
using ETicaret.Domen.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        readonly IProductReadRepostory _readcontext;
        readonly IProductWriteRepostory _writecontext;
        public ProductController(IProductReadRepostory readcontext, IProductWriteRepostory writecontext)
        {
            _readcontext=readcontext;
            _writecontext=writecontext;
        }

        [HttpGet]
        public IActionResult GetAdd() 
        {
            _writecontext.AddAsync(new Product {Name="Corab",Price=2,Stock=4 });
            _writecontext.SaveChangeAsync();
            return Ok();
        }


    }
}
