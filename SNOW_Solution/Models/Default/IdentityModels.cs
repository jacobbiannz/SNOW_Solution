using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using SNOW_Solution.Configuration;
using System.Data.Entity.Validation;

namespace SNOW_Solution.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public int ApplicationUserId { get; set; }

        //   public DateTime CreateTime { get; set; }

        //  public DateTime LastLogin { get; set; }
        public Subscriber MySubscriber { get; set; }
        //  [ForeignKey("MyCompany")]
        // public int CompanyId { get; set; }
        public Company MyCompany { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class CompanyDbContext : IdentityDbContext<ApplicationUser>
    {
        public CompanyDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        #region
        public DbSet<Company> Companys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<RegionState> RegionalStates { get; set; }
        #endregion

        static CompanyDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role 
            Database.SetInitializer<CompanyDbContext>(new ApplicationDbInitializer());
        }

        public static CompanyDbContext Create()
        {
            return new CompanyDbContext();
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //store - all user
            //customrer - all order
            try
            {

           
                modelBuilder.Configurations.Add(new CountryConfiguration());
                modelBuilder.Configurations.Add(new RegionalStateConfiguration());
                modelBuilder.Configurations.Add(new CityConfiguration());
                modelBuilder.Configurations.Add(new AddressConfiguration());
                modelBuilder.Configurations.Add(new Companyfiguration());
                modelBuilder.Configurations.Add(new StoreConfiguration());
                modelBuilder.Configurations.Add(new CategoryConfiguration());
                modelBuilder.Configurations.Add(new BrandConfiguration());
                modelBuilder.Configurations.Add(new ProductConfiguration());
           



                modelBuilder.Entity<Size>()
                    .HasMany(d => d.AllInventories)
                    .WithRequired(l => l.MySize).WillCascadeOnDelete(false);

           

                modelBuilder.Entity<OrderStatus>()
                    .HasMany(d => d.AllOrders)
                    .WithRequired(l => l.MyOrderStatus).WillCascadeOnDelete(false);

        

                modelBuilder.Entity<Promotion>()
                    .HasMany(d => d.AllProducts)
                    .WithMany(l => l.AllPromotions)
                    .Map(dl => {
                        dl.MapLeftKey("PromotionId");
                        dl.MapRightKey("ProductionId");
                    });

                modelBuilder.Entity<Promotion>()
                    .HasMany(d => d.AllOrders)
                    .WithMany(l => l.AllPromotions)
                    .Map(dl => {
                        dl.MapLeftKey("PromotionId");
                        dl.MapRightKey("OrderId");
                    });

          

                modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
                modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
                modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public DbSet<RoleViewModel> RoleViewModels { get; set; }

       
      
    }
}