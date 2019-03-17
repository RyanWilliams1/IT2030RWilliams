using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RyansAuthIndividualAccounts.Startup))]
namespace RyansAuthIndividualAccounts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
