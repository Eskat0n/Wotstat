using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wotstat.Startup))]
namespace Wotstat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
