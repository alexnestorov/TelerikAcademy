using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Engine.CommandExtensions.Abstracts
{
    public abstract class CommandProvider : ICommandProvider
    {
        private const string InvalidCommand = "InvalidCommand";

        private ICommandProvider NextCommandProvider { get; set; }

        public string ProvideCommand(ICommand command, IDealershipEngine engine)
        {
            if (this.IsValidCommand(command))
            {
                return this.ProvideSingleCommand(command, engine);
            }

            if (this.NextCommandProvider != null)
            {
                return this.NextCommandProvider.ProvideSingleCommand(command, engine);
            }

            return InvalidCommand;
        }

        public void ProvideNextCommand(ICommandProvider nextCommandProvider)
        {
            this.NextCommandProvider = nextCommandProvider;
        }

        public abstract string ProvideSingleCommand(ICommand command, IDealershipEngine engine);

        protected virtual bool IsValidCommand(ICommand command)
        {
            var isValidCommand = command.Name.Equals(InvalidCommand);

            return isValidCommand;
        }

        protected void ValidateRange(int? value, int min, int max, string message)
        {
            if (value < min || value >= max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
