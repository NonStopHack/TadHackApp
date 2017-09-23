using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LastFmTestApp.Startup))]
namespace LastFmTestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
