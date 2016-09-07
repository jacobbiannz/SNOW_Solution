namespace SNOW_Solution.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    sealed class Configuration : DbMigrationsConfiguration<CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
         //   ContextKey = "SNOW_Solution.Models.CompanyDbContext";
        }

        protected override void Seed(CompanyDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser { UserName = "snowAdmin@gmail.com" };
            var guest = new ApplicationUser { UserName = "guest@gmail.com" };

            userManager.Create(user, "123456");
            userManager.Create(guest, "abcdef");
            roleManager.Create(new IdentityRole { Name = Role.adminRole });
            userManager.AddToRole(user.Id, Role.adminRole);

            roleManager.Create(new IdentityRole { Name = Role.customRole });
            userManager.AddToRole(guest.Id, Role.customRole);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
