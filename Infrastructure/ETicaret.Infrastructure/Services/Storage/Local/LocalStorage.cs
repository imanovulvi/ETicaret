﻿using ETicaret.Application.Abstractions.Storage.Local;
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
            string _path=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot",path);
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            List<(string path, string name)> fileLst = new();
            foreach (IFormFile item in formFiles)
            {
                string newFileName = Guid.NewGuid() + Path.GetExtension(item.FileName);
                string fullpath = Path.Combine(_path, newFileName);
               await using FileStream fileStream = new(fullpath, FileMode.Create, FileAccess.Write, FileShare.None, (1024 * 1024), true);
                await item.CopyToAsync(fileStream);
               await fileStream.FlushAsync();
                fileLst.Add((fullpath, newFileName));
            }
            return fileLst;
        }
    }
}