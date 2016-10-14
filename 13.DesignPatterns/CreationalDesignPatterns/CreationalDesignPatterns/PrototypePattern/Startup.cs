using PrototypePattern.Abstracts;

namespace PrototypePattern
{
    public class Startup
    {
        public static void Main()
        {
            var cocaCola2L = new CocaCola(1.99m);

            cocaCola2L.Clone();
        }
    }
}
