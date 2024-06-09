using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.ModelViews
{
    public class VM_ProductFile_Get
    {
     
        public Guid ProductId { get; set; }
        public Guid ProductFileId { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Base64 { get; set; }
    }
}
