using System.Linq;

using Dealership.Engine.CommandExtensions.Abstracts;

namespace Dealership.Engine.CommandExtensions
{
    public class LoginCommand : CommandProvider, ICommandProvider
    {
        private const string CommandName = "Login";
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string WrongUsernameOrPassword = "Wrong username or password!";
        private const string UserLoggedIn = "User {0} successfully logged in!";

        public override string ProvideSingleCommand(ICommand command, IDealershipEngine engine)
        {
            var username = command.Parameters[0];
            var password = command.Parameters[1];

            if (engine.LoggedUser != null)
            {
                return string.Format(UserLoggedInAlready, engine.LoggedUser.Username);
            }

            var userFound = engine.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (userFound == null || userFound.Password != password)
            {
                return WrongUsernameOrPassword;
            }

            engine.LoggedUser = userFound;

            return string.Format(UserLoggedIn, username);
        }

        protected override bool IsValidCommand(ICommand command)
        {
            var isValidCommand = command.Name.Equals(CommandName);

            return isValidCommand;
        }
    }
}
