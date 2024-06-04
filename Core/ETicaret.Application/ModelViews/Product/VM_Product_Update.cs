using ETicaret.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.ModelViews
{
    public class VM_Product_Update
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required,Range(1,1000)]
        public double Price { get; set; }
        [Required,Range(1, 1000)]
        public int Stock { get; set; }

        public static implicit operator Product(VM_Product_Update model)
        {
            return new Product
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock
            };

        }

        public static explicit operator VM_Product_Update(Product model)
        {
            return new VM_Product_Update
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock
            };

        }
    }
}
