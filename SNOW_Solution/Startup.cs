using System;
using Microsoft.Owin;
using Owin;
using Snow.Data;
[assembly: OwinStartupAttribute(typeof(SNOW_Solution.Startup))]
namespace SNOW_Solution
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            StartupAuth.ConfigureAuth(app);
        }

    }
}
