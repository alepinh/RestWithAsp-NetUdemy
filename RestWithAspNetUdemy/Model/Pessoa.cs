using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Model
{
    public class Pessoa
    {
        public long? id { get; set; }
        public string Nome { get; set; }
        public string sobreNome { get; set; }
        public string Endereco { get; set; }
        public string Genero { get; set; }


    }
}
