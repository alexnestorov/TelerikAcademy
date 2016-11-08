using Dealership.Engine.CommandExtensions.Abstracts;

namespace Dealership.Engine.CommandExtensions
{
    public class LogoutCommand : CommandProvider, ICommandProvider
    {
        private const string CommandName = "Logout";
        private const string UserLoggedOut = "You logged out!";

        public override string ProvideSingleCommand(ICommand command, IDealershipEngine engine)
        {
            engine.LoggedUser = null;
            return UserLoggedOut;
        }

        protected override bool IsValidCommand(ICommand command)
        {
            return command.Name == "Logout";
        }
    }
}
