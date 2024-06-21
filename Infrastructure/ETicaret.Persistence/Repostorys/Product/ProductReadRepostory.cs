using ETicaret.Application.Repostorys;
using ETicaret.Domen.Entitys;
using ETicaret.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.Repostorys
{
    public class ProductReadRepostory : ReadRepostory<Product>, IProductReadRepostory
    {
        public ProductReadRepostory(ETicaretContext context) : base(context)
        {
        }

    }
}
