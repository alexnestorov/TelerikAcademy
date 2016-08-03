using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Cosmetics.Tests")]
namespace Cosmetics.Contracts
{
    internal interface IShoppingCart
    {
        void AddProduct(IProduct product);

        void RemoveProduct(IProduct product);

        bool ContainsProduct(IProduct product);

        decimal TotalPrice();
    }
}
