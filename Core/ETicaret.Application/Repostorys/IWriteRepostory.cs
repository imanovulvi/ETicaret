using ETicaret.Domen.BaseEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.Repostorys
{
    public interface IWriteRepostory<T>:IRepostory<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T value);
        Task<bool> AddRangeAsync(List<T> values);
        Task<bool> Remove(string Id);
        bool RemoveRange(List<T> values);

        bool Update(T value);
        bool UpdateRange(List<T> values);

    }
}
