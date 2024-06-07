using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Domen.Entitys
{
    public class ProductFile:File
    {
        public List<Product> Products { get; set; }
    }
}
