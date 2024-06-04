using ETicaret.Application.ModelViews;
using ETicaret.Domen.Entitys;
using ETicaret.WebApp_.AppClasses;


using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebApp_.Areas.admin_panel.Controllers
{
    [Area("admin_panel")]
    public class ProductController : Controller
    {
     
        HttpClientService httpClientService = new(new RequestParametrs {BaseUrl= "https://localhost:7254/api",Controller="Product" });

        public async Task<IActionResult> Get(int page=1,int size=5)
        {
            
            VM_Product_Get list=await httpClientService.GetAsync<VM_Product_Get>(page,size);

            return View(list);
        }
        [HttpPost]
        public async Task Post(VM_Product_Create product_Create)
        {
            await httpClientService.PostAsync(product_Create);
        }

        public async Task Deleted(string Id) 
        {
            await httpClientService.DeleteAsync(Id);
         
        }

        public async Task<IActionResult> Update(string Id) 
        {
            VM_Product_Update p = (VM_Product_Update)await httpClientService.GetByIdAsync<Product>(Id);
            return View(p);
        }
        [HttpPost]
        public async Task<IActionResult> Update(VM_Product_Update model)
        {
            await httpClientService.PutAsync(model);

            return Redirect("/admin_panel/Product/Get");
        }

    }
}
