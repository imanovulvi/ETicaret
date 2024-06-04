using ETicaret.Domen.BaseEntitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Domen.Entitys
{
    public class Product:BaseEntity
    {
    
        public string Name { get; set; }
       
        public double Price { get; set; }
        public int Stock { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
