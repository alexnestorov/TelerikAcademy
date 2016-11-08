using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Ninject.Modules;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;

using Dealership.Contracts;
using Dealership.Models;
using Dealership.Engine;
using Dealership.Factories;
using Dealership.Engine.CommandExtensions.Abstracts;

namespace Dealership
{
    public class DealershipModule : NinjectModule
    {
        private const string CarName = "Car";
        private const string VehicleName = "Vehicle";
        private const string TruckName = "Truck";
        private const string MotorcycleName = "Motorcycle";
        private const string UserName = "User";
        private const string CommentName = "Comment";
        private const string CommandName = "Command";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath
                (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            Bind<IDealershipFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommandProvider>()
                .ToMethod(context =>
                {
                    var assembly = this.GetType()
                                       .GetTypeInfo()
                                       .Assembly;
                    IList<Type> typeInfos = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(CommandProvider))).ToList();

                    var commandHandlers = new List<ICommandProvider>();
                    for (var i = 0; i < typeInfos.Count; i++)
                    {
                        var singleCommandProvider = Activator.CreateInstance(typeInfos[i]) as ICommandProvider;
                        commandHandlers.Add(singleCommandProvider);
                        if (i != 0)
                        {
                            commandHandlers[i - 1].ProvideNextCommand(singleCommandProvider);
                        }
                    }

                    return commandHandlers.FirstOrDefault();
                });

            Bind<IVehicle>().To<Car>().Named(CarName);
            Bind<IVehicle>().To<Truck>().Named(TruckName);
            Bind<IVehicle>().To<Motorcycle>().Named(MotorcycleName);
            Bind<IComment>().To<Comment>().Named(CommentName);
            Bind<IUser>().To<User>().Named(UserName);
            Bind<ICommand>().To<Command>().Named(CommandName);
        }
    }
}
