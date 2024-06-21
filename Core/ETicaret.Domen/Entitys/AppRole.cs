using ETicaret.Domen.BaseEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Domen.Entitys
{
    public class AppRole:BaseEntity
    {
        public string Role { get; set; }
        public ICollection<AppUsersAppRole> AppUsersAppRoles { get; set; }
    }
}
