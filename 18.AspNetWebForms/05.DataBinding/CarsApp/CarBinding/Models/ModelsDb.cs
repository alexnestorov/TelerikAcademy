using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsApp.Models
{
    public class ModelsDb
    {

        public ModelsDb()
        {
                
        }

        public IEnumerable<Producer> GetProducers()
        {
            var producers = new List<Producer>()
            {
                new Producer()
                {
                    Name = "Audi",
                    Models = new List<string>()
                    {
                        "100", "A4", "A8", "S2", "S5"
                    }
                },
                new Producer()
                {
                    Name = "BMW",
                    Models = new List<string>()
                    {
                        "M3", "M5", "E320", "Bavarec", "125"
                    }
                },
                new Producer()
                {
                    Name = "Peugeot",
                    Models = new List<string>()
                    {
                        "306", "306", "405", "Trista i pesh :)", "Още някакъв си друг модел"
                    }
                }
            };
            return producers;
        }

        public IEnumerable<string> GetEngineTypes()
        {
            var engineTypes = new List<string>()
            {
                "Gasoline",
                "Diesel",
                "Electrical",
            };

            return engineTypes;
        }

        public IEnumerable<Extra> GetExtras()
        {
            var extras = new List<Extra>()
            {
                new Extra()
                {
                    Id = 1,
                    Name = "Anti-blocking system (ABS)"
                },
                new Extra()
                {
                    Id = 2,
                    Name = "Airbag"
                },
            };

            return extras;
        }
    }
}