using Ninject.Modules;
using Ninject.Extensions.Conventions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Cosmetics.Contracts;
using Cosmetics.Engine;
using Ninject.Extensions.Factory;
using Cosmetics.Engine.Abstracts;
using Cosmetics.Common;

namespace Cosmetics.NinjectBindings
{
    public class CosmeticsModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
            {
                x.FromAssembliesInPath
                (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            this.Rebind<ICosmeticsEngine>().To<CosmeticsEngine>().InSingletonScope();
            this.Bind<IInputOutputProvider>().To<ConsoleInputOutputProvider>();
            this.Bind<ICosmeticsFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommandProvider>()
                .ToMethod(context =>
              {
                  var assembly = this.GetType()
                                     .GetTypeInfo()
                                     .Assembly;
                  IList<Type> typeInfos = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(CommandProvider))).ToList();

                  var commandProviders = new List<ICommandProvider>();
                  for (var i = 0; i < typeInfos.Count; i++)
                  {
                      var singleCommandProvider = Activator.CreateInstance(typeInfos[i]) as ICommandProvider;
                      commandProviders.Add(singleCommandProvider);
                  }

                  return commandProviders.FirstOrDefault();
              });
        }
    }
}
