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
    public class Superhero
    {
        public int Id { get; set; }

        public Superhero()
        {
            this.Powers = new HashSet<Power>();
            this.Fractions = new HashSet<Fraction>();
        }

        [Required]
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Index(IsUnique = true)]
        public string SecretIdentity { get; set; }

        [Required]
        public AllignmentType Allignment { get; set; }

        [Required]
        public string Story { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public int PowerId { get; set; }

        public virtual ICollection<Power> Powers { get; set; }

        public int FractionId { get; set; }

        public virtual ICollection<Fraction> Fractions { get; set; }


    }
}
