using System;
using System.Reflection;

using AdapterPattern.Contracts;
using Ninject;

namespace AdapterPattern
{
    /// <summary>
    /// Executes example for Adapter pattern.
    /// You can see this article below for more clear information about this design pattern.
    /// http://www.dofactory.com/net/adapter-design-pattern
    /// </summary>
    public class Startup
    {
        public static void Main()
        {
            // Create adapter and place a request
            // For creation I am using Ninject IoC Container.
            // More information about it you can see on the link below.
            // https://github.com/ninject/Ninject/blob/master/README.md
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            ITarget target = kernel.Get<ITarget>();

            Console.WriteLine(target.Request());

            // Wait for user
            Console.ReadKey();
        }
    }
}
