using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Snow.testing.Startup))]
namespace Snow.testing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
