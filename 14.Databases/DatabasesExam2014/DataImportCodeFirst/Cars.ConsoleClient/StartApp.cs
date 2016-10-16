using Cars.Data;
using Cars.Data.Migrations;
using System.Data.Entity;
using System.Linq;

namespace Cars.ConsoleClient
{
   public class StartApp
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());

            var db = new CarsDbContext();

            db.Cars.Count();
        }
    }
}
