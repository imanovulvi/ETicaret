using ETicaret.Application.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public async Task<List<(string path,string name)>> FileUpload(IFormFileCollection formFiles, string path)
        {

            var _path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{path}");
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
            List<(string path, string name)> lst= new();

            foreach (IFormFile file in formFiles)
            {
                string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string fullpath = Path.Combine(_path, filename);
                await using FileStream str = new FileStream(fullpath, FileMode.Create, FileAccess.Write, FileShare.None, (1024 * 1024), true);
                await file.CopyToAsync(str);
                await str.FlushAsync();

                lst.Add((fullpath,filename));
            }

            return lst;
        }
    }
}
