using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Armadura.Domain 
{
    public class DataContext : DbContext
    {
        public DataContext(): base("DefaultConnection")
        {
                
        }

        public DbSet<Armadura.Domain.Empresas> Empresas { get; set; }

        public DbSet<Armadura.Domain.Clave> Claves { get; set; }

    }
}
