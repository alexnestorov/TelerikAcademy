using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Engine.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Engine.CommandExtensions
{
    public class CreateToothpasteCommand : CommandProvider, ICommandProvider
    {
        private const string ToothpasteAlreadyExist = "Toothpaste with name {0} already exists!";
        private const string ToothpasteCreated = "Toothpaste with name {0} was created!";

        public override string ProvideSingleCommand(ICommand command)
        {
            var toothpasteName = command.Parameters[0];
            var toothpasteBrand = command.Parameters[1];
            var toothpastePrice = decimal.Parse(command.Parameters[2]);
            var toothpasteGender = this.GetGender(command.Parameters[3]);
            var toothpasteIngredients = command.Parameters[4].Trim().Split(',').ToList();
            return this.CreateToothpaste(toothpasteName, toothpasteBrand, toothpastePrice, toothpasteGender, toothpasteIngredients);
        }


        private string CreateToothpaste(string toothpasteName, string toothpasteBrand, decimal toothpastePrice, GenderType toothpasteGender, IList<string> toothpasteIngredients)
        {
            if (this.Engine.Products.ContainsKey(toothpasteName))
            {
                return string.Format(ToothpasteAlreadyExist, toothpasteName);
            }

            var toothpaste = this.Engine.Factory.GetToothpaste(toothpasteName, toothpasteBrand, toothpastePrice, toothpasteGender, toothpasteIngredients);
            this.Engine.Products.Add(toothpasteName, toothpaste);

            return string.Format(ToothpasteCreated, toothpasteName);
        }
    }
}
