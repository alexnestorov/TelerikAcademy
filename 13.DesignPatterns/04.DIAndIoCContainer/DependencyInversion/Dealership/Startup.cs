using System.Reflection;

using Ninject;

using Dealership.Engine;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            IDealershipEngine dealershipEngine = kernel.Get<IDealershipEngine>();
            dealershipEngine.Start();
        }
    }
}
