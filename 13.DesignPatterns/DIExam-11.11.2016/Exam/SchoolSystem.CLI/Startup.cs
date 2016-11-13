using Ninject;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using System.Reflection;

namespace SchoolSystem.Cli
{
    public class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var reader = kernel.Get<IReader>();
            var writer = kernel.Get<IWriter>();
            var parser = kernel.Get<IParser>();

            var engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}