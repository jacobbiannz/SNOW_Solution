using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SNOW_Solution.Startup))]
namespace SNOW_Solution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
