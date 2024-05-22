using ETicaret.Domen.BaseEntitys;
using ETicaret.Domen.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.Context
{
    public class ETicaretContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ETicaretContext(DbContextOptions options) :base(options)
        {
            
        }

        public override int SaveChanges()
        {
            var datas=ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified=>item.Entity.UpdateDate=DateTime.UtcNow

                } ;
            }

            return base.SaveChanges();
        }
    }
}
