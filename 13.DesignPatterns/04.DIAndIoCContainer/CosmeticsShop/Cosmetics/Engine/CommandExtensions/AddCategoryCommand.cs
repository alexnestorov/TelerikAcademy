using Cosmetics.Contracts;
using Cosmetics.Engine.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Engine.CommandExtensions
{
    public class AddCategoryCommand : CommandProvider, ICommandProvider
    {
        private const string ProductDoesNotExist = "Product {0} does not exist!";
        private const string ProductAddedToCategory = "Product {0} added to category {1}!";
        private const string CategoryDoesNotExist = "Category {0} does not exist!";



        public override string ProvideSingleCommand(ICommand command)
        {
            var categoryNameToAdd = command.Parameters[0];
            var productToAdd = command.Parameters[1];
            return this.AddToCategory(categoryNameToAdd, productToAdd);
        }

        private string AddToCategory(string categoryNameToAdd, string productToAdd)
        {
            if (!this.Engine.Categories.ContainsKey(categoryNameToAdd))
            {
                return string.Format(CategoryDoesNotExist, categoryNameToAdd);
            }

            if (!this.Engine.Products.ContainsKey(productToAdd))
            {
                return string.Format(ProductDoesNotExist, productToAdd);
            }

            var category = this.Engine.Categories[categoryNameToAdd];
            var product = this.Engine.Products[productToAdd];

            category.AddCosmetics(product);

            return string.Format(ProductAddedToCategory, productToAdd, categoryNameToAdd);
        }
    }
}
