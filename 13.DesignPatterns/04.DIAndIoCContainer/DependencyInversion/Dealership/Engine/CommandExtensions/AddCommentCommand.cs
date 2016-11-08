using Dealership.Engine.CommandExtensions.Abstracts;
using System;
using System.Linq;

namespace Dealership.Engine.CommandExtensions
{
    public class AddCommentCommand : CommandProvider, ICommandProvider
    {
        private const string CommandName = "AddComment";
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string VehicleDoesNotExist = "The vehicle does not exist!";
        private const string CommentAddedSuccessfully = "{0} added comment successfully!";

        public override string ProvideSingleCommand(ICommand command, IDealershipEngine engine)
        {
            var content = command.Parameters[0];
            var author = command.Parameters[1];
            var vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            var comment = engine.Factory.GetComment(content);
            comment.Author = engine.LoggedUser.Username;
            var user = engine.Users.FirstOrDefault(u => u.Username == author);

            if (user == null)
            {
                return string.Format(NoSuchUser, author);
            }

            this.ValidateRange(vehicleIndex, 0, user.Vehicles.Count, VehicleDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];

            engine.LoggedUser.AddComment(comment, vehicle);

            return string.Format(CommentAddedSuccessfully, engine.LoggedUser.Username);
        }

        protected override bool IsValidCommand(ICommand command)
        {
            var isValidCommand = command.Name.Equals(CommandName);

            return isValidCommand;
        }
    }
}
