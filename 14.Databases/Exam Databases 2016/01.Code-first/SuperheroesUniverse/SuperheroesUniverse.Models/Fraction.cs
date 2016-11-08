using SuperheroesUniverse.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesUniverse.Models
{
    public class Fraction
    {
        private ICollection<Planet> planets;
        private ICollection<Superhero> superheroes;

        public Fraction()
        {
            this.planets = new HashSet<Planet>();
            this.superheroes = new HashSet<Superhero>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        AllignmentType Allignment { get; set; }

        public int PlanetId { get; set; }

        public virtual ICollection<Planet> Planets
        {
            get
            {
                return this.planets;
            }

            set
            {
                this.planets = value;
            }
        }

        public int SuperheroId { get; set; }

        public virtual ICollection<Superhero> Superheroes
        {
            get
            {
                return this.superheroes;
            }

            set
            {
                this.superheroes = value;
            }
        }

    }
}
