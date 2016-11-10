using Cosmetics.Contracts;
using Cosmetics.Engine;
using Ninject;
using System.Reflection;

namespace Cosmetics
{
    public class CosmeticsProgram
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            ICosmeticsEngine cosmeticsEngine = kernel.Get<ICosmeticsEngine>();
            cosmeticsEngine.Start();
        }
    }
}
