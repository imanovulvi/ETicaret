using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.Services
{
    public interface IFileService
    {
        Task<List<(string path, string name)>> FileUpload(IFormFileCollection formFiles,string path);
    }
}
