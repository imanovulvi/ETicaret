﻿using ETicaret.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.ModelViews
{
    public class VM_Product_Update
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
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
