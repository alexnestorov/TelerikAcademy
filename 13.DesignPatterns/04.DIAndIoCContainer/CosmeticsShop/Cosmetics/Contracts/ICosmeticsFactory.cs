namespace Cosmetics.Contracts
{
    using System.Collections.Generic;

    using Cosmetics.Common;

    public interface ICosmeticsFactory
    {
        ICategory GetCategory(string name);

        IShampoo GetShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage);

        IToothpaste GetToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients);

        IShoppingCart GetShoppingCart();

        ICommand GetCommand(string input);
    }
}
