using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Toyshops.Startup))]
namespace Toyshops
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
