using ETicaret.Application.Repostorys;
using ETicaret.Domen.Entitys;
using ETicaret.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Persistence.Repostorys
{
    public class AppUserWriteRepostary : WriteRepostory<AppUser>, IAppUserWriteRepostary
    {
        public AppUserWriteRepostary(ETicaretContext context) : base(context)
        {
        }
    }
}
