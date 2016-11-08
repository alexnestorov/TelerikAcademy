﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public int PlanetId { get; set; }

        public virtual Planet Planet { get; set; }
    }
}