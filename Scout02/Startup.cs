using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Scout02.Startup))]
namespace Scout02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
