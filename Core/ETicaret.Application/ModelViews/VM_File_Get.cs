using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.ModelViews
{
    public class VM_File_Get
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Base64 { get; set; }
    }
}
