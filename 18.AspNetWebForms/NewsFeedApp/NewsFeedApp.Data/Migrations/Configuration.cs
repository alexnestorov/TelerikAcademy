using System.Data.Entity.Migrations;
using System.Linq;

using NewsFeedApp.Data.Models;

namespace NewsFeedApp.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<NewsFeedDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NewsFeedDbContext context)
        {
            if (context.Articles.Any())
            {
                return;
            }

            var user = new User()
            {
                UserName = "Alexander"
            };

            context.Users.Add(user);

            context.SaveChanges();

            var seed = new SeedData(user);

            seed.Categories.ForEach(x => context.Categories.Add(x));

            seed.Articles.ForEach(x => context.Articles.Add(x));

            context.SaveChanges();
        }
    }
}
