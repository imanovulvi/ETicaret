using ETicaret.Application.ModelViews;
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
        public IActionResult Get() 
        {
            
            return Ok(_readcontext.GetAll(false).ToList());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(string Id)
        {
            var product=await _readcontext.GetByIdAsync(Id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Product_Create product)
        {
            await _writecontext.AddAsync(product);
            await _writecontext.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Product_Update product)
        {

            _writecontext.Update(product);
            await _writecontext.SaveAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            await _writecontext.Remove(Id);
            await _writecontext.SaveAsync();
            return Ok();
        }
    }
}
