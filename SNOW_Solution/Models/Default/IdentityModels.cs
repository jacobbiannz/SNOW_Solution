using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;

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
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
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
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegionState>()
                .HasMany(d => d.AllCities)
                .WithRequired(l => l.MyRegionState)
                .WillCascadeOnDelete(false);

            //store - all user
            //customrer - all order


            modelBuilder.Entity<Brand>()
                .HasMany(d=>d.AllProducts)
                .WithRequired(l=>l.MyBrand).WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(d => d.AllProducts)
                .WithRequired(l => l.MyStore).WillCascadeOnDelete(false);


            modelBuilder.Entity<Size>()
                .HasMany(d => d.AllInventories)
                .WithRequired(l => l.MySize).WillCascadeOnDelete(false);

            modelBuilder.Entity<Size>()
                .HasMany(d => d.AllOrderDetails)
                .WithRequired(l => l.MySize).WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderStatus>()
                .HasMany(d => d.AllOrders)
                .WithRequired(l => l.MyOrderStatus).WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(d => d.AllProducts)
                .WithRequired(l => l.MyCategory).WillCascadeOnDelete(false);

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

            modelBuilder.Entity<Company>()
                .HasMany(d => d.AllProducts)
                .WithRequired(l => l.MyCompany).WillCascadeOnDelete(false);






            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public System.Data.Entity.DbSet<SNOW_Solution.Models.RoleViewModel> RoleViewModels { get; set; }

        public System.Data.Entity.DbSet<SNOW_Solution.Models.Brand> Brands { get; set; }

        public System.Data.Entity.DbSet<SNOW_Solution.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<SNOW_Solution.Models.Store> Stores { get; set; }
    }
}