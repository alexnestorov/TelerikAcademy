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
    public class CreateShampooCommand : CommandProvider, ICommandProvider
    {
        private const string ShampooAlreadyExist = "Shampoo with name {0} already exists!";
        private const string ShampooCreated = "Shampoo with name {0} was created!";
        

        public override string ProvideSingleCommand(ICommand command)
        {
            var shampooName = command.Parameters[0];
            var shampooBrand = command.Parameters[1];
            var shampooPrice = decimal.Parse(command.Parameters[2]);
            var shampooGender = this.GetGender(command.Parameters[3]);
            var shampooMilliliters = uint.Parse(command.Parameters[4]);
            var shampooUsage = this.GetUsage(command.Parameters[5]);
            return this.CreateShampoo(shampooName, shampooBrand, shampooPrice, shampooGender, shampooMilliliters, shampooUsage);
        }

        private string CreateShampoo(string shampooName, string shampooBrand, decimal shampooPrice, GenderType shampooGender, uint shampooMilliliters, UsageType shampooUsage)
        {
            if (this.Engine.Products.ContainsKey(shampooName))
            {
                return string.Format(ShampooAlreadyExist, shampooName);
            }

            var shampoo = this.Engine.Factory.GetShampoo(shampooName, shampooBrand, shampooPrice, shampooGender, shampooMilliliters, shampooUsage);
            this.Engine.Products.Add(shampooName, shampoo);

            return string.Format(ShampooCreated, shampooName);
        }


    }
}
