using Cosmetics.Contracts;
using Cosmetics.Engine.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Engine.CommandExtensions
{
    public class AddToShoppingCartCommand : CommandProvider, ICommandProvider
    {
        private const string ProductDoesNotExist = "Product {0} does not exist!";
        private const string ProductAddedToShoppingCart = "Product {0} was added to the shopping cart!";

        public override string ProvideSingleCommand(ICommand command)
        {
            var productToAddToCart = command.Parameters[0];
            return this.AddToShoppingCart(productToAddToCart);
        }

        private string AddToShoppingCart(string productName)
        {
            if (!this.Engine.Products.ContainsKey(productName))
            {
                return string.Format(ProductDoesNotExist, productName);
            }

            var product = this.Engine.Products[productName];
            this.Engine.ShoppingCart.AddProduct(product);

            return string.Format(ProductAddedToShoppingCart, productName);
        }
    }
}
