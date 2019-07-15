using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(maganement.Startup))]
namespace maganement
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
