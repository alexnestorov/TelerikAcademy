using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IntroMVC.Startup))]
namespace IntroMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
