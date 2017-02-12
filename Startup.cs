using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppVentas.Startup))]
namespace WebAppVentas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
