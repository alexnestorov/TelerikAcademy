using Dealership.Engine.CommandExtensions.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Engine.CommandExtensions
{
    public class RemoveVehicleCommand : CommandProvider, ICommandProvider
    {
        private const string CommandName = "RemoveVehicle";
        private const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";
        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";

        public override string ProvideSingleCommand(ICommand command, IDealershipEngine engine)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            this.ValidateRange(vehicleIndex, 0, engine.LoggedUser.Vehicles.Count, RemovedVehicleDoesNotExist);

            var vehicle = engine.LoggedUser.Vehicles[vehicleIndex];
            engine.LoggedUser.RemoveVehicle(vehicle);

            return string.Format(VehicleRemovedSuccessfully, engine.LoggedUser.Username);
        }

        protected override bool IsValidCommand(ICommand command)
        {
            var isValidCommand = command.Name.Equals(CommandName);

            return isValidCommand;
        }
    }
}
