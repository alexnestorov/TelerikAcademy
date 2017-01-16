using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsFeedApp.Startup))]
namespace NewsFeedApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
