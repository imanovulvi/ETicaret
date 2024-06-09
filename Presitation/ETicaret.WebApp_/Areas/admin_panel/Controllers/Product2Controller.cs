using ETicaret.Application.ModelViews;
using ETicaret.Domen.Entitys;
using ETicaret.WebApp_.AppClasses;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebApp_.Areas.admin_panel.Controllers
{
    [Area("admin_panel")]
    public class Product2Controller : Controller
    {
        HttpClientService httpClientService = new(new RequestParametrs { BaseUrl = "https://localhost:7254/api", Controller = "Product" });

        [HttpGet]
        public IActionResult Get(int page = 1, int size = 5)
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetData(int page = 1, int size = 5)
        {
            VM_Product_Get list = await httpClientService.GetAsync<VM_Product_Get>(page, size);
            return Json(list);
        }

        [HttpPost]
        public async Task Post(VM_Product_Create vM_Product)
        {
            await httpClientService.PostAsync<VM_Product_Create>(vM_Product);

        }

        [HttpPost]
        public async Task Delete(string id)
        {
            await httpClientService.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<IActionResult> Put(string id)
        {
            return Json(await httpClientService.GetByIdAsync<VM_Product_Update>(id));
        }

        [HttpPost]
        public async Task Put(VM_Product_Update vM_Product)
        {
            await httpClientService.PutAsync(vM_Product);
        }

        [HttpPost]
        public async Task AddFiles(string id)
        {
           await httpClientService.PostImageAsync(Request.Form.Files, id);
         
        }


        [HttpGet]
        public async Task<JsonResult> GetFiles(string Id)
        {

            List<VM_ProductFile_Get> a = await httpClientService.GetFileAsync<VM_ProductFile_Get>(Id);
            return Json(a);
            //todo gelencekde men bur try cach qoyacam
        }

        [HttpGet]
        public async Task RemoveFile(string productid, string fileid)
        {

            await httpClientService.GetFileRemoveAsync(productid,fileid);
            //return Json(a);
        }
    }
}
