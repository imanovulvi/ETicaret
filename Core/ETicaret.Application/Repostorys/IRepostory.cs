using ETicaret.Domen.BaseEntitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.Repostorys
{
    public interface IRepostory<T> where T : BaseEntity
    {
        public DbSet<T> Table { get;  }
    }
}
