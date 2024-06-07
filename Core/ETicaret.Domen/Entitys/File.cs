using ETicaret.Domen.BaseEntitys;
using ETicaret.Domen.Entitys.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Domen.Entitys
{
    public class File:BaseEntity
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public ContainerType ContanierType { get; set; }
        [NotMapped]
        public override DateTime UpdateDate { get => base.UpdateDate; set => base.UpdateDate = value; }
    }
}
