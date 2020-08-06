using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practica1WS.Startup))]
namespace Practica1WS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
