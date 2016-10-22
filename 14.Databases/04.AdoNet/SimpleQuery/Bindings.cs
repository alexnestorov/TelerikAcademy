using System.Data.Common;
using System.Data.SqlClient;

using Ninject.Modules;

namespace SimpleQuery
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<DbConnection>().To<SqlConnection>();
            Bind<IWriter>().To<ConsoleWriterProvider>();
            Bind<DbQueries>().ToSelf();
        }
    }
}
