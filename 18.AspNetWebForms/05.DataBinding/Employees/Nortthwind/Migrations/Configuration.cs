namespace Nortthwind.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Nortthwind.NorthwindEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NorthwindEntities context)
        {
            if (context.Employees.Any())
            {
                return;
            }

            var seed = new SeedData();

            seed.Employees.ToList().ForEach(x => context.Employees.Add(x));

            context.SaveChanges();
        }
    }
}
