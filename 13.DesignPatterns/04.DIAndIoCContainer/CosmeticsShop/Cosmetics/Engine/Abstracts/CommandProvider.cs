using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Engine.Abstracts
{
    public abstract class CommandProvider : ICommandProvider
    {
        private const string InvalidCommand = "Invalid command name: {0}!";
        private const string InvalidGenderType = "Invalid gender type!";
        private const string InvalidUsageType = "Invalid usage type!";

        private readonly ICosmeticsEngine engine;

        public ICosmeticsEngine Engine { get; }

        public virtual string ProvideSingleCommand(ICommand command)
        {
            return string.Format(InvalidCommand, command.Name);
        }

        protected virtual GenderType GetGender(string genderAsString)
        {
            switch (genderAsString)
            {
                case "men":
                    return GenderType.Men;
                case "women":
                    return GenderType.Women;
                case "unisex":
                    return GenderType.Unisex;
                default:
                    throw new InvalidOperationException(InvalidGenderType);
            }
        }

        protected virtual UsageType GetUsage(string usageAsString)
        {
            switch (usageAsString)
            {
                case "everyday":
                    return UsageType.EveryDay;
                case "medical":
                    return UsageType.Medical;
                default:
                    throw new InvalidOperationException(InvalidUsageType);
            }
        }
    }
}
