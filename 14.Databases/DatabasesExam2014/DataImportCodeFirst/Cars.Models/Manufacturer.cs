﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Models
{
    public class Manufacturer
    {
        private ICollection<Car> cars;

        public Manufacturer()
        {
            this.cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Index(IsUnique = false)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars
        {
            get
            {
                return this.cars;
            }

            set
            {
                this.cars = value;
            }
        }
    }
}
