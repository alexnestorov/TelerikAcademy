using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesUniverse.Models
{
    public class Relationship
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FirstHeroId { get; set; }

        public virtual Superhero FirstHero { get; set; }

        public int SecondHeroId { get; set; }

        public virtual Superhero SecondHero { get; set; }
    }
}
