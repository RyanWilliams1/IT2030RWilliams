using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RyansEventManager.Startup))]
namespace RyansEventManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
