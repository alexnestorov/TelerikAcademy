using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeesApp.Startup))]
namespace EmployeesApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
