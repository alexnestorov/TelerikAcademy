using System.Text;

using Dealership.Common.Enums;
using Dealership.Engine.CommandExtensions.Abstracts;

namespace Dealership.Engine.CommandExtensions
{
    public class ShowUsersCommand : CommandProvider, ICommandProvider
    {
        private const string CommandName = "ShowUsers";
        private const string YouAreNotAnAdmin = "You are not an admin!";

        public override string ProvideSingleCommand(ICommand command, IDealershipEngine engine)
        {
            if (engine.LoggedUser.Role != Role.Admin)
            {
                return YouAreNotAnAdmin;
            }

            var builder = new StringBuilder();
            builder.AppendLine("--USERS--");
            var counter = 1;
            foreach (var user in engine.Users)
            {
                builder.AppendLine(string.Format("{0}. {1}", counter, user.ToString()));
                counter++;
            }

            return builder.ToString().Trim();
        }

        protected override bool IsValidCommand(ICommand command)
        {
            var isValidCommand = command.Name.Equals(CommandName);
            return isValidCommand;
        }
    }
}
