using MediatorPattern.Abstracts;
using MediatorPattern.Contracts;
using MediatorPattern.Models;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class Bindings : NinjectModule
    {
        private static readonly IList<IAircraft> RegisteredAircrafts = new List<IAircraft>();
        private static readonly IAirTrafficControl RegionalATC = new RegionalAirTrafficControl(RegisteredAircrafts);

        public override void Load()
        {
            Bind<IAirTrafficControl>().To<RegionalAirTrafficControl>();

            Bind<IList<IAircraft>>().To<List<IAircraft>>();

            Bind<Airbus380>().ToSelf()
                             .WithConstructorArgument("AI568")
                             .WithConstructorArgument(RegionalATC);

            Bind<Boeing747>().ToSelf()
                             .WithConstructorArgument("AI568")
                             .WithConstructorArgument(RegionalATC);

            Bind<EasyJet>().ToSelf()
                           .WithConstructorArgument("EasyJet")
                             .WithConstructorArgument(RegionalATC);
        }
    }
}
