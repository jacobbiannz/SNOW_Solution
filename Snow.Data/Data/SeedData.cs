namespace SNOW_Solution.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Snow.Model;
    using Snow.Data;
    using System.Data.Entity.Migrations;
    using System;
    using System.IO;

    sealed class SeedData : DbMigrationsConfiguration<CompanyDBContext>
    {
        public SeedData()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            //   ContextKey = "Snow.Model.CompanyDbContext";
        }

        protected override void Seed(CompanyDBContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var subscriber = new Subscriber();
            var user = new ApplicationUser { UserName = "snowAdmin@gmail.com", Subscriber = subscriber };
            var guest = new ApplicationUser { UserName = "guest@gmail.com", Subscriber = subscriber };

            userManager.Create(user, "123456");
            userManager.Create(guest, "abcdef");
            roleManager.Create(new IdentityRole { Name = "Admin" });
            userManager.AddToRole(user.Id, "Admin");

            roleManager.Create(new IdentityRole { Name = "Customer" });
            userManager.AddToRole(guest.Id, "Customer");

            var country = new Country
            {
                Name = "NewZealand",
                Code = "64",
                Id = 1
            };

            var regionalState = new RegionState
            {
                MyCountry = country,

                Name = "Auckland",
                Id = 1
            };


            var city = new City
            {
                Name = "Auckland",
                MyCountry = country,
                MyRegionState = regionalState,

                Id = 1
            };

            var address = new Address
            {
                AddressLine1 = "queen st",
                MyCity = city,
                //PhoneNumber = "02188888",
                //Email = "demo@hotmail.com",

                Id = 1
            };

            var company = new Company
            {
                Name = "Snow",
                //MyAddress = address,

                Id = 1
            };

            var store = new Store
            {
                Name = "Auckland City",
                //MyAddress = address,
                MyCompany = company,

                Id = 1
            };

            var store1 = new Store
            {
                Name = "Auckland Parnell",
                //MyAddress = address,
                MyCompany = company,

                Id = 1
            };

            var brand1 = new Brand
            {
                Name = "LV",
                MyCompany = company,

                Id = 1
            };
            var brand2 = new Brand
            {
                Name = "Prada",
                MyCompany = company,

                Id = 2
            };
            var brand3 = new Brand
            {
                Name = "Dior",
                MyCompany = company,

                Id = 3
            };


            var category1 = new Category
            {
                Name = "T-Shirt",
                MyCompany = company,

                Id = 1
            };

            var OrderStatus1 = new OrderStatus
            {
                Name = "Processing",
                MyCompany = company
            };

            var OrderStatus2 = new OrderStatus
            {
                Name = "Pending",
                MyCompany = company
            };

            var OrderStatus3 = new OrderStatus
            {
                Name = "Delivered",
                MyCompany = company
            };

            var size1 = new Size
            {
                Name = "S",
                MyCategory = category1
            };

            var size2 = new Size
            {
                Name = "M",
                MyCategory = category1
            };

            var size3 = new Size
            {
                Name = "L",
                MyCategory = category1
            };


            var category2 = new Category
            {
                Name = "Shoes",
                MyCompany = company,

                Id = 2
            };
            var category3 = new Category
            {
                Name = "Polo",
                MyCompany = company,

                Id = 3
            };

            var PaymentType1 = new PaymentType
            {
                Name = "cash",
                Description = "cash",
                CompanyId = 1
            };
            var PaymentType2 = new PaymentType
            {
                Name = "card",
                Description = "card",
                CompanyId = 1
            };

            var product1 = new Product
            {
                Name = "Patterned Cotton Socks",
                Description = "Patterned Cotton Socks",
                MyCompany = company,
                MyCategory = category1,
                MyBrand = brand1,
                //MyStore = store,
               // Id = 1
            };

            var product2 = new Product
            {
                Name = "Embroidered Cotton-Twill Baseball Cap",
                Description = "Embroidered Cotton-Twill Baseball Cap",
                MyCompany = company,
                MyCategory = category2,
                MyBrand = brand2,
                //MyStore = store,

                //Id = 2
            };
            var product3 = new Product
            {
                Name = "GucciGhost Engraved Sterling Silver Cufflinks",
                Description = "GucciGhost Engraved Sterling Silver Cufflinks",
                MyCompany = company,
                MyCategory = category3,
                MyBrand = brand3,
                //MyStore = store,

               // Id = 3
            };

            var uniqueID = new UniqueID
            {
                ProductBarcode = 1000,
                MyCompany = company
            };

            context.Countries.Add(country);
            context.RegionalStates.Add(regionalState);
            context.Cities.Add(city);
            context.Addresses.Add(address);
            context.Companys.Add(company);
            context.Stores.Add(store);
            context.Stores.Add(store1);
            context.Brands.Add(brand1);
            context.Brands.Add(brand2);
            context.Brands.Add(brand3);
            context.Categories.Add(category1);
            context.Sizes.Add(size1);
            context.Sizes.Add(size2);
            context.Sizes.Add(size3);
            context.Categories.Add(category2);
            context.Categories.Add(category3);
            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.Orderstatuses.Add(OrderStatus1);
            context.Orderstatuses.Add(OrderStatus2);
            context.Orderstatuses.Add(OrderStatus3);
            context.PaymentTypes.Add(PaymentType1);
            context.PaymentTypes.Add(PaymentType2);
            context.UniqueIDs.Add(uniqueID);

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
