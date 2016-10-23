using System.Collections.Generic;

using CompositePattern.Contracts;
using Ninject.Modules;
using CompositePattern.Models;

namespace CompositePattern
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ICollection<IEmployee>>().To<List<IEmployee>>();
            Bind<IEmployee>().To<Worker>().WhenInjectedExactlyInto<Worker>();
            Bind<IEmployee>().To<Manager>().WhenInjectedExactlyInto<Manager>();
        }
    }
}
