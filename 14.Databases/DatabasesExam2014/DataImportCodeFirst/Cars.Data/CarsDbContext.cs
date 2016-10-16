using Cars.Models;
using System.Data.Entity;

namespace Cars.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
            : base("Cars")
        {

        }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<Dealer> Dealers { get; set; }

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }

        public virtual IDbSet<City> Cities { get; set; }
    }
}
