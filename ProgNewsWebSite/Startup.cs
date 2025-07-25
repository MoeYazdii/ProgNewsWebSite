using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProgNewsWebSite.Startup))]
namespace ProgNewsWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
