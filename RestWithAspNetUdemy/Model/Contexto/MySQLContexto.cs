using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Model.Contexto
{
    public class MySQLContexto : DbContext
    {

        public MySQLContexto()
        {

        }

        public MySQLContexto(DbContextOptions<MySQLContexto> options) : base (options) 
        { 
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
