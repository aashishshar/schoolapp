using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEB_APP_SCHOOL_NET.Startup))]
namespace WEB_APP_SCHOOL_NET
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
