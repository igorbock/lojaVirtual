using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Dominio.Entidades
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext() : base("DbContext")
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
