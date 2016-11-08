using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesUniverse.Models
{
    public class Power
    {
        public int Id { get; set; }

        [Required]
        [StringLength(35, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

    }
}
