﻿using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Snow.Data.Infrastructure;
using Snow.Service;
using SNOW_Solution.Mapping;
using SNOW_Solution.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SNOW_Solution.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
            Mapper.Initialize(AutoMapperConfiguration.Configure);
            
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(ImageService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}