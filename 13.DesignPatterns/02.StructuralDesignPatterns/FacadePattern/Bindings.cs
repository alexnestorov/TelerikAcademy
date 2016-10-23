using Ninject.Modules;

using FacadePattern.Contracts;
using FacadePattern.Models;

namespace FacadePattern
{
   public class Bindings : NinjectModule
    {
        private string name = "Ann McKinley";
        public override void Load()
        {
            Bind<ICustomer>().To<Customer>().WithConstructorArgument<string>(name);
            Bind<IBank>().To<Bank>();
            Bind<ILoan>().To<Loan>();
            Bind<ICredit>().To<Credit>();
            Bind<Mortgage>().ToSelf();
            Bind<string>().ToSelf();
        }
    }
}
