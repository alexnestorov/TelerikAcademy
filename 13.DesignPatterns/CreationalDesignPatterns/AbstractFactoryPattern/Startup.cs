using System.Collections.Generic;

namespace AbstractFactoryPattern
{
    public class Startup
    {
        public static void Main()
        {
            var factory = new BulgarianSportFactory();

            factory.CreateBasketballClub();
            factory.CreateFootballClub(new List<Game>());
            factory.CreateVolleyballClub();
        }
    }
}
