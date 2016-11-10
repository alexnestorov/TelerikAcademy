using Cosmetics.Contracts;
using Cosmetics.Engine.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Engine.CommandExtensions
{
    public class ShowCategoryCommand : CommandProvider, ICommandProvider
    {
        private const string CategoryDoesNotExist = "Category {0} does not exist!";

        public override string ProvideSingleCommand(ICommand command)
        {
            var categoryToShow = command.Parameters[0];
            return this.ShowCategory(categoryToShow);
        }

        private string ShowCategory(string categoryToShow)
        {
            if (!this.Engine.Categories.ContainsKey(categoryToShow))
            {
                return string.Format(CategoryDoesNotExist, categoryToShow);
            }

            var category = this.Engine.Categories[categoryToShow];

            return category.Print();
        }
    }
}
