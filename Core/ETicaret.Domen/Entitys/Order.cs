using ETicaret.Domen.BaseEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Domen.Entitys
{
    public class Order:BaseEntity
    {
        public string Adress { get; set; }
        public double Description { get; set; }
        public ICollection<Product> Products { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
