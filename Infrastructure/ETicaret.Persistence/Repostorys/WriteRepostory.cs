using ETicaret.Application.Repostorys;
using ETicaret.Domen.BaseEntitys;
using ETicaret.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.Repostorys
{
    public class WriteRepostory<T> : IWriteRepostory<T> where T : BaseEntity
    {
        readonly ETicaretContext _context;
        public WriteRepostory(ETicaretContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T value)
        {
           EntityEntry entityEntry=await Table.AddAsync(value);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> values)
        {
            await Table.AddRangeAsync(values);
            return true;
        }

        public bool Remove(T value)
        {
            
            EntityEntry entityEntry = Table.Remove(value);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> values)
        {
            Table.RemoveRange(values);
            return true;
        }

        public async Task SaveChangeAsync()
        {
           await _context.SaveChangesAsync();
        }

        public bool Update(T value)
        {
            EntityEntry entityEntry = Table.Update(value);
            return entityEntry.State == EntityState.Modified;
        }

        public bool UpdateRange(List<T> values) 
        {
            Table.UpdateRange(values);
            return true;
        }
    }
}
