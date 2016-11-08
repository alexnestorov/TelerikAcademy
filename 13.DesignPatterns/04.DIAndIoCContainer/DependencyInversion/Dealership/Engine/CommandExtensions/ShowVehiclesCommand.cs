using System.Linq;

using Dealership.Engine.CommandExtensions.Abstracts;

namespace Dealership.Engine.CommandExtensions
{
    public class ShowVehiclesCommand : CommandProvider, ICommandProvider
    {
        private const string CommandName = "ShowVehicles";
        private const string NoSuchUser = "There is no user with username {0}!";

        public override string ProvideSingleCommand(ICommand command, IDealershipEngine engine)
        {
            var username = command.Parameters[0];

            var user = engine.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                return string.Format(NoSuchUser, username);
            }

            return user.PrintVehicles();
        }

        protected override bool IsValidCommand(ICommand command)
        {
            var isValidCommand = command.Name.Equals(CommandName);
            return isValidCommand;
        }
    }
}
