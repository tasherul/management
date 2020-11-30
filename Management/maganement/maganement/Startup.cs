using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(management.Startup))]
namespace management
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
