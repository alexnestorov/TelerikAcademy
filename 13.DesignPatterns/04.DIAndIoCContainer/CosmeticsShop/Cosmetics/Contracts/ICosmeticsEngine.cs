using System.Collections.Generic;

namespace Cosmetics.Contracts
{
    public interface ICosmeticsEngine : IEngine
    {
        ICosmeticsFactory Factory { get; }

        IShoppingCart ShoppingCart { get; }

        IDictionary<string, ICategory> Categories { get; }

        IDictionary<string, IProduct> Products { get; }
    }
}
