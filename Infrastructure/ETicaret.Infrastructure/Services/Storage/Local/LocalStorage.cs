using ETicaret.Application.Abstractions.Storage.Local;
using F=ETicaret.Domen.Entitys;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        public string ConvertBase64(string path, string name)
        {
            string imagePath = Path.Combine(path, name);
            byte[] imagesBytes=System.IO.File.ReadAllBytes(imagePath);
            return $"data:image/jpeg;base64,{Convert.ToBase64String(imagesBytes)}";

        }

        public async Task DeleteAsync(string path, string name)
            =>File.Delete($"{path}\\{name}"); 
        

        public List<string> GetFiles(string path)
        {
            DirectoryInfo d = new(path);
            return d.GetFiles().Select(x => x.Name).ToList();

        }

        public bool HasFile(string path, string name)
        =>  File.Exists($"{path}\\{name}");
        

        public async Task<List<(string pathOrContanerName, string name)>> UploadAsync(IFormFileCollection formFiles, string path)
        {
            string _path=Path.Combine("wwwroot",path);
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            List<(string path, string name)> fileLst = new();
            foreach (IFormFile item in formFiles)
            {
                string newFileName = Guid.NewGuid() + Path.GetExtension(item.FileName);
                string fullpath = Path.Combine(Directory.GetCurrentDirectory(),_path, newFileName);
               await using FileStream fileStream = new(fullpath, FileMode.Create, FileAccess.Write, FileShare.None, (1024 * 1024), true);
                await item.CopyToAsync(fileStream);
               await fileStream.FlushAsync();
                fileLst.Add((_path, newFileName));
            }
            return fileLst;
        }
    }
}
