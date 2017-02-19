using System;
using Microsoft.Owin;
using Owin;
using Snow.Data;
using SNOW_Solution;

[assembly: OwinStartupAttribute(typeof(Snow.Web.Startup))]

namespace Snow.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            StartupAuth.ConfigureAuth(app);
        }

    }
}
