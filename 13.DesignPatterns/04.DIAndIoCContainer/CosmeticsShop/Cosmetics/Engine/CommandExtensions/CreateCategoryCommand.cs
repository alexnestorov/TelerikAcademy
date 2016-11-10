using Cosmetics.Contracts;
using Cosmetics.Engine.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Engine.CommandExtensions
{
    public class CreateCategoryCommand : CommandProvider, ICommandProvider
    {
        private const string CategoryExists = "Category with name {0} already exists!";
        private const string CategoryCreated = "Category with name {0} was created!";
        private const string CategoryDoesNotExist = "Category {0} does not exist!";

        public override string ProvideSingleCommand(ICommand command)
        {
            var categoryName = command.Parameters[0];

            return this.CreateCategory(categoryName);
        }

        private string CreateCategory(string categoryName)
        {
            if (this.Engine.Categories.ContainsKey(categoryName))
            {
                return string.Format(CategoryExists, categoryName);
            }

            var category = this.Engine.Factory.GetCategory(categoryName);
            this.Engine.Categories.Add(categoryName, category);

            return string.Format(CategoryCreated, categoryName);
        }
    }
}
