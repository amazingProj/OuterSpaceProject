using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PlanetContext : DbContext
    {
        public PlanetContext() : base()
        {

        }

        public DbSet<Planet> Planets { get; set; }
    }
}
