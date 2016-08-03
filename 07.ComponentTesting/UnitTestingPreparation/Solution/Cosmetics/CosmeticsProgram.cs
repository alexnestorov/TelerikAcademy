using Cosmetics.Engine;
using Cosmetics.Products;

namespace Cosmetics
{
    public class CosmeticsProgram
    {
        public static void Main()
        {
            var factory = new CosmeticsFactory();
            var shoppingCart = new ShoppingCart();
            var parser = new ConsoleCommandParser();
            var engine = new CosmeticsEngine(factory, shoppingCart, parser);

            engine.Start();
        }
    }
}
