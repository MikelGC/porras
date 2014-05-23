using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Porras.Web.Startup))]
namespace Porras.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
