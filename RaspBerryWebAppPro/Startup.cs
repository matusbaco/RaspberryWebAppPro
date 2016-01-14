using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RaspBerryWebAppPro.Startup))]
namespace RaspBerryWebAppPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
