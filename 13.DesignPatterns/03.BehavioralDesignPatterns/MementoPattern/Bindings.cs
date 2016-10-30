using MementoPattern.Contracts;
using MementoPattern.Models;
using Ninject.Modules;

namespace MediatorPattern
{
    /// <summary>
    /// Setup information for bindings in current project.
    /// </summary>
    public class Bindings : NinjectModule
    {
        /// <summary>
        /// Returns information of loading bindings in project.
        /// </summary>
        public override void Load()
        {
            Bind<IMemento>().To<PersonMemento>();
            Bind<IPerson>().To<Person>();
            Bind<ICaretaker>().To<PersonCaretaker>();
        }
    }
}
