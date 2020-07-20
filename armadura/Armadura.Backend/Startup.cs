using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Armadura.Backend.Startup))]
namespace Armadura.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
