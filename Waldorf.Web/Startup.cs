using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Waldorf.Web.Startup))]
namespace Waldorf.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
