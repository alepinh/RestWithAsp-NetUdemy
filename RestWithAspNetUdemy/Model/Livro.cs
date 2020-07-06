using RestWithAspNetUdemy.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Model
{
    public class Livro : BaseEntity
    {
        //[Key]
        //[Column("Id")]
        //public long Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataLancamento { get; set; }


    }
}
