using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_EF_FluentAPI.Startup))]
namespace MVC_EF_FluentAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
