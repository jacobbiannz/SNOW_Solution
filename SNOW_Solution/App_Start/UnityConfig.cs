using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using SNOW_Solution.Factories;
using SNOW_Solution.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNOW_Solution.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IProductRepository, ProductRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}