using Cosmetics.Contracts;
using Cosmetics.Engine.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Engine.CommandExtensions
{
    public class TotalPriceCommand : CommandProvider, ICommandProvider
    {
        private const string TotalPriceInShoppingCart = "${0} total price currently in the shopping cart!";

        public override string ProvideSingleCommand(ICommand command)
        {
            return string.Format(TotalPriceInShoppingCart, this.Engine.ShoppingCart.TotalPrice());
        }
    }
}
