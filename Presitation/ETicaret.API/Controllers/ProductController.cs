using ETicaret.Application.Abstractions.Storage;
using ETicaret.Application.ModelViews;


using ETicaret.Application.Repostorys;
using ETicaret.Application.Services;
using ETicaret.Domen.Entitys;
using ETicaret.Infrastructure.Services;
using ETicaret.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ETicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        readonly IProductReadRepostory _productReadRepostory;
        readonly IProductWriteRepostory _productWriteRepostory;

        readonly IStorage _storage;

        readonly IFileReadRepostory _fileReadRepostory;
        readonly IFileWriteRepostory _fileWriteRepostory;
     


        readonly IProductFileReadRepostory _productFileReadRepostory;
        readonly IProductFileWriteRepostory _productFileWriteRepostory;

        readonly IInvoceFileReadRepostory _invoceFileReadRepostory;
        readonly IInvoceFileWriteRepostory _invoceFileWriteRepostory;

        public ProductController(IProductReadRepostory productReadRepostory, IProductWriteRepostory productWriteRepostory, IStorage storage, IFileReadRepostory fileReadRepostory, IFileWriteRepostory fileWriteRepostory, IProductFileReadRepostory productFileReadRepostory, IProductFileWriteRepostory productFileWriteRepostory, IInvoceFileReadRepostory invoceFileReadRepostory, IInvoceFileWriteRepostory invoceFileWriteRepostory)
        {
            _productReadRepostory = productReadRepostory;
            _productWriteRepostory = productWriteRepostory;
            _storage = storage;
            _fileReadRepostory = fileReadRepostory;
            _fileWriteRepostory = fileWriteRepostory;
            _productFileReadRepostory = productFileReadRepostory;
            _productFileWriteRepostory = productFileWriteRepostory;
            _invoceFileReadRepostory = invoceFileReadRepostory;
            _invoceFileWriteRepostory = invoceFileWriteRepostory;
        }

        [HttpGet]
        public IActionResult Get(int page,int size)
        {

            int count=_productReadRepostory.GetAll(false).Count();
            var products = _productReadRepostory.GetAll(false).OrderBy(x => x.Price).Skip(((page * size) - size)).Take(size).Select(x => new { x.Id, x.Name, x.Price, x.Stock }).ToList();

            return Ok(new { count,products});
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(string Id)
        {
            var product=await _productReadRepostory.GetByIdAsync(Id,false);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Product_Create product)
        {
            if (ModelState.IsValid)
            {
                await _productWriteRepostory.AddAsync(product);
                await _productWriteRepostory.SaveAsync();
                return Ok();
            }
           return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Product_Update product)
        {
            if (ModelState.IsValid)
            {
                Product p = await _productReadRepostory.GetByIdAsync(product.Id.ToString());

                p.Name = product.Name;
                p.Price = product.Price;
                p.Stock = product.Stock;

                _productWriteRepostory.Update(p);

                await _productWriteRepostory.SaveAsync();
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id is not null)
            {
                await _productWriteRepostory.Remove(Id);
                await _productWriteRepostory.SaveAsync();
                return Ok();
            }
            return NotFound();
           
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(IFormFileCollection formFile)
        {

           List<(string path,string name)> filelst= await _storage.UploadAsync(formFile, "Images\\Product");
            foreach (var item in filelst)
            {
                await _fileWriteRepostory.AddAsync(new() { Name = item.name, Path = item.path });
                await _fileWriteRepostory.SaveAsync();
            }
         
            return Ok(new { path=filelst});


        }
    }
}
