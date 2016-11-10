using Cosmetics.Contracts;
using Cosmetics.Engine.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Engine.CommandExtensions
{
    public class RemoveFromShoppingCartCommand : CommandProvider, ICommandProvider
    {
        private const string ProductDoesNotExist = "Product {0} does not exist!";
        private const string ProductDoesNotExistInShoppingCart = "Shopping cart does not contain product with name {0}!";
        private const string ProductRemovedFromShoppingCart = "Product {0} was removed from the shopping cart!";

        public override string ProvideSingleCommand(ICommand command)
        {
            var productToRemoveFromCart = command.Parameters[0];
            return this.RemoveFromShoppingCart(productToRemoveFromCart);
        }

        private string RemoveFromShoppingCart(string productName)
        {
            if (!this.Engine.Products.ContainsKey(productName))
            {
                return string.Format(ProductDoesNotExist, productName);
            }

            var product = this.Engine.Products[productName];

            if (!this.Engine.ShoppingCart.ContainsProduct(product))
            {
                return string.Format(ProductDoesNotExistInShoppingCart, productName);
            }

            this.Engine.ShoppingCart.RemoveProduct(product);

            return string.Format(ProductRemovedFromShoppingCart, productName);
        }
    }
}
