﻿using System;

using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Engine.CommandExtensions.Abstracts;

namespace Dealership.Engine.CommandExtensions
{
    public class AddVehicleCommand : CommandProvider, ICommandProvider
    {
        private const string CommandName = "AddVehicle";
        private const string VehicleAddedSuccessfully = "{0} added vehicle successfully!";

        public override string ProvideSingleCommand(ICommand command, IDealershipEngine engine)
        {
            var type = command.Parameters[0];
            var make = command.Parameters[1];
            var model = command.Parameters[2];
            var price = decimal.Parse(command.Parameters[3]);
            var additionalParam = command.Parameters[4];

            var typeEnum = (VehicleType)Enum.Parse(typeof(VehicleType), type, true);
            IVehicle vehicle = null;

            switch (typeEnum)
            {
                case VehicleType.Car:
                    vehicle = engine.Factory.GetCar(make, model, price, int.Parse(additionalParam));
                    break;
                case VehicleType.Motorcycle:
                    vehicle = engine.Factory.GetMotorcycle(make, model, price, additionalParam);
                    break;
                case VehicleType.Truck:
                    vehicle = engine.Factory.GetTruck(make, model, price, int.Parse(additionalParam));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            engine.LoggedUser.AddVehicle(vehicle);

            return string.Format(VehicleAddedSuccessfully, engine.LoggedUser.Username);
        }

        protected override bool IsValidCommand(ICommand command)
        {
            var isValidCommand = command.Name.Equals(CommandName);

            return isValidCommand;
        }
    }
}
