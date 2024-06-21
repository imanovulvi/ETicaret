using ETicaret.Application.UnitOfWork;
using ETicaret.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ETicaretContext _context;
        public UnitOfWork(ETicaretContext context)
        {
            _context=context;
        }

        public async Task<int> SaveAsync()
        {
          return  await _context.SaveChangesAsync();
        }
    }
}
