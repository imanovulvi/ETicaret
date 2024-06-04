using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.Domen.Entitys;

namespace ETicaret.Application.ModelViews
{
    public class VM_Product_Get
    {
        public int Count { get; set; }
        public List<Product> Products { get; set; }
    }
}
