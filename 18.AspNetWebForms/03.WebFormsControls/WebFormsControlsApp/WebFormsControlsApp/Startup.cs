using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormsControlsApp.Startup))]
namespace WebFormsControlsApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
