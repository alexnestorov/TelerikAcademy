using Ninject.Modules;
using AdapterPattern.Models;
using AdapterPattern.Contracts;

namespace CompositePattern
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ITarget>().To<Adapter>();
            Bind<ISpecificTarget>().To<Adaptee>();
        }
    }
}
