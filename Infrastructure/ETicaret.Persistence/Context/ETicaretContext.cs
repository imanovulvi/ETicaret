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

        public DbSet<Domen.Entitys.File> Files { get; set; }
        public DbSet<ProductFile> ProductFiles { get; set; }
        public DbSet<InvoceFile> InvoceFiles { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUsersAppRole> AppUsersAppRoles { get; set; }

        public ETicaretContext(DbContextOptions options) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUsersAppRole>().HasKey(x=>new { x.AppUserId,x.AppRoleId});

            modelBuilder.Entity<AppUsersAppRole>().HasOne(x=>x.AppUser).WithMany(x=>x.AppUsersAppRoles).HasForeignKey(x=>x.AppUserId);
            modelBuilder.Entity<AppUsersAppRole>().HasOne(x => x.AppRole).WithMany(x => x.AppUsersAppRoles).HasForeignKey(x => x.AppRoleId);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified => item.Entity.UpdateDate = DateTime.UtcNow

                };
            }

            return base.SaveChanges();
        }
    }
}
