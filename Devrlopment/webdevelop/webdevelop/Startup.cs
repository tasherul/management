using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webdevelop.Startup))]
namespace webdevelop
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
