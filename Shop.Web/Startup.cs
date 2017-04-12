using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shop.Web.Startup))]
namespace Shop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
