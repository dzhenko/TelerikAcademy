using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chat.Startup))]
namespace Chat
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
