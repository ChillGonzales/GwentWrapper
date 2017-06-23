using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GwentSite.WebUI.Startup))]
namespace GwentSite.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
