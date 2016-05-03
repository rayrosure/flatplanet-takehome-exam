using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlatPlanet.Startup))]
namespace FlatPlanet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
