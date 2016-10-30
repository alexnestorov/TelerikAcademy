using System.Reflection;

using MediatorPattern.Models;
using Ninject;

namespace MediatorPattern
{
    /// <summary>
    /// Example for Mediator Design Pattern in real world environment.
    /// For more information you can see the link below.
    /// https://dotnetcodr.com/2013/06/06/design-patterns-and-practices-in-net-the-mediator-pattern/
    /// </summary>
    public class Startup
    {
        public static void Main()
        {
            // For creation I am using Ninject IoC Container.
            // More information about it you can see on the link below.
            // https://github.com/ninject/Ninject/blob/master/README.md
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var aircraft1 = kernel.Get<Airbus380>();

            var aircraft2 = kernel.Get<Boeing747>();

            var aircraft3 = kernel.Get<EasyJet>();

            aircraft1.Altitude += 100;

            aircraft3.Altitude = 1100;
        }
    }
}
