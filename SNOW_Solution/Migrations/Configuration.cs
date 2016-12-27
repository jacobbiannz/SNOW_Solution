namespace SNOW_Solution.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
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

        //    GetCategories().ForEach(c => context.Categories.Add(c));
          //  GetBrands().ForEach(b => context.Brands.Add(b));
         //   GetCompanies().ForEach(c => context.Companys.Add(c));
         //   GetProducts().ForEach(p => context.Products.Add(p));


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
        static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {
                    Name = "T-Shirt",
                    CompanyId = 1
                },
                new Category {
                    Name = "Shoes",
                    CompanyId = 1
                },
                new Category {
                    Name = "Polo",
                    CompanyId = 1
                }
            };
        }
        static List<Brand> GetBrands()
        {
            return new List<Brand>
            {
                new Brand {
                    Name = "LV",
                     CompanyId = 1
                },
                new Brand {
                    Name = "Prada",
                     CompanyId = 1
                },
                new Brand {
                    Name = "Dior",
                     CompanyId = 1
                }
            };
        }

        static List<Company> GetCompanies()
        {
            return new List<Company>
            {
                new Company {
                    Name = "Snow",
                    AddressId = 1
                }
              
            };
        }

        static List<Address> GetAddresses()
        {
            return new List<Address>
            {
                new Address {
                    AddressLine1 = "queen st",
                    CityId = 1
                }

            };
        }

        static List<City> GetCities()
        {
            return new List<City>
            {
                new City {
                    Name = "Auckland",
                    CountryId = 1
                }

            };
        }

        static List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country {
                    Name = "NewZealand",
                    Code = "64"
                }

            };
        }

        static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {
                    Name = "Patterned Cotton Socks",
                    Description = "Patterned Cotton Socks",
                    CategoryId = 1,
                    BrandId =1
                },
                new Product {
                    Name = "Embroidered Cotton-Twill Baseball Cap",
                    Description = "Patterned Cotton Socks",
                    CategoryId = 1,
                    BrandId =1
                },
                new Product {
                    Name = "GucciGhost Engraved Sterling Silver Cufflinks",
                    Description = "Patterned Cotton Socks",
                    CategoryId = 1,
                    BrandId =1
                }
            };
        }
    }
}
