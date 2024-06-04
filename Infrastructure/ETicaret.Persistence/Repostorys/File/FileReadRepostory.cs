using ETicaret.Application.Repostorys;
using F=ETicaret.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.Persistence.Context;

namespace ETicaret.Persistence.Repostorys
{
    public class FileReadRepostory : ReadRepostory<F::File>, IFileReadRepostory
    {
        public FileReadRepostory(ETicaretContext context) : base(context)
        {
        }
    }
}
