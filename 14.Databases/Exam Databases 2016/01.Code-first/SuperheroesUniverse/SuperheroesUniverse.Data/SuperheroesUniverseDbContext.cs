using SuperheroesUniverse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesUniverse.Data
{
    public class SuperheroesUniverseDbContext : DbContext
    {
        public SuperheroesUniverseDbContext()
            : base("name=SuperheroesUniverse")
        {
                
        }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Fraction> Fractions { get; set; }

        public virtual IDbSet<Planet> Planets { get; set; }

        public virtual IDbSet<Power> Powers { get; set; }

        //public virtual IDbSet<Relationship> Relationships { get; set; }

        public virtual IDbSet<Superhero> Superheroes { get; set; }
    }
}
