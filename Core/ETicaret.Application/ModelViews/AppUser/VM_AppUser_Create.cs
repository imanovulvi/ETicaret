using ETicaret.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Application.ModelViews
{
    public class VM_AppUser_Create
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public static implicit operator AppUser(VM_AppUser_Create model) 
        {
            return new AppUser { 
            Email=model.Email,
            Name=model.Name,    
            Surname=model.Surname,
            Password=model.Password

            };
        }
    }
}
