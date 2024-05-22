using ETicaret.Domen.BaseEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Domen.Entitys
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }



    }
}
