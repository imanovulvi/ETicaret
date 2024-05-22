using ETicaret.Application.Repostorys;
using ETicaret.Domen.BaseEntitys;
using ETicaret.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.Repostorys
{
    public class ReadRepostory<T> : IReadRepostory<T> where T : BaseEntity
    {
        readonly ETicaretContext _context;
        public ReadRepostory(ETicaretContext context)
        {
            _context = context;
        }



        public DbSet<T> Table { get => _context.Set<T>(); }

        public IQueryable<T> GetAll(bool tracker = true)
        {
            if (!tracker)
             return Table.AsNoTracking();
            return Table;
        }

        public async Task<T> GetByIdAsync(string Id, bool tracker)
        {
            if (!tracker)
                return await Table.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==Guid.Parse(Id));
            return await Table.FirstOrDefaultAsync(x=>x.Id==Guid.Parse(Id));
        }

        public async Task<T> GetSingleAsync(string Id, bool tracker)
        {
            if (!tracker)
            return await Table.AsNoTracking().SingleOrDefaultAsync(x=>x.Id == Guid.Parse(Id));

            return await Table.SingleOrDefaultAsync(x=>x.Id==Guid.Parse(Id));
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracker)
        {
            if (!tracker)
              return  Table.AsNoTracking().Where(expression);
            return Table.Where(expression);
        }
    }
}
