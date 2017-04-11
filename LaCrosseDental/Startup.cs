using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaCrosseDental.Startup))]
namespace LaCrosseDental
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
