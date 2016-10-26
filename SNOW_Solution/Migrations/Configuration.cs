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
            var subscriber = new Subscriber();
            var user = new ApplicationUser { UserName = "snowAdmin@gmail.com", MySubscriber = subscriber };
            var guest = new ApplicationUser { UserName = "guest@gmail.com", MySubscriber = subscriber };

            userManager.Create(user, "123456");
            userManager.Create(guest, "abcdef");
            roleManager.Create(new IdentityRole { Name = "Admin" });
            userManager.AddToRole(user.Id, "Admin");

            roleManager.Create(new IdentityRole { Name = "Customer" });
            userManager.AddToRole(guest.Id, "Customer");
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
