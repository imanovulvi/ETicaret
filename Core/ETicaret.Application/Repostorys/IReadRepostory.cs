using ETicaret.Domen.BaseEntitys;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.Repostorys
{
    public interface IReadRepostory<T>:IRepostory<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracker=true);
        Task<T> GetSingleAsync(string Id, bool tracker = true);

        Task<T> GetByIdAsync(string Id, bool tracker = true);

        IQueryable<T> GetWhere(Expression<Func<T,bool>> expression,bool tracker = true);
            

    }
}
