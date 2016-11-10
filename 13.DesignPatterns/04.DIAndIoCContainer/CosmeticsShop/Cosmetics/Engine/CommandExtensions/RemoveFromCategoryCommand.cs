using Cosmetics.Contracts;
using Cosmetics.Engine.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Engine.CommandExtensions
{
    public class RemoveFromCategoryCommand : CommandProvider, ICommandProvider
    {
        private const string CategoryDoesNotExist = "Category {0} does not exist!";
        private const string ProductRemovedCategory = "Product {0} removed from category {1}!";
        private const string ProductDoesNotExist = "Product {0} does not exist!";

        private IInputOutputProvider provider;

        public IInputOutputProvider Provider { get; set; }

        public override string ProvideSingleCommand(ICommand command)
        {
            var categoryNameToRemove = command.Parameters[0];
            var productToRemove = command.Parameters[1];
            return this.RemoveCategory(categoryNameToRemove, productToRemove);
        }

        private string RemoveCategory(string categoryNameToAdd, string productToRemove)
        {
            if (!this.Engine.Categories.ContainsKey(categoryNameToAdd))
            {
                return string.Format(CategoryDoesNotExist, categoryNameToAdd);
            }

            if (!this.Engine.Products.ContainsKey(productToRemove))
            {
                return string.Format(ProductDoesNotExist, productToRemove);
            }

            var category = this.Engine.Categories[categoryNameToAdd];
            var product = this.Engine.Products[productToRemove];

            category.RemoveCosmetics(product, this.Provider);

            return string.Format(ProductRemovedCategory, productToRemove, categoryNameToAdd);
        }
    }
}
