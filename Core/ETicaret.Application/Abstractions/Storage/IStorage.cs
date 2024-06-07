using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<List<(string pathOrContanerName, string name)>> UploadAsync(IFormFileCollection formFiles, string pathOrContanerName);
        Task DeleteAsync(string pathOrContanerName, string name);
        List<string> GetFiles(string pathOrContanerName);
        bool HasFile(string pathOrContanerName, string name);
    }
}
