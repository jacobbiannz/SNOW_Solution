using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace SNOW_Solution.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int ApplicationUserId { get; set; }

        //   public DateTime CreateTime { get; set; }

        //  public DateTime LastLogin { get; set; }

        [ForeignKey("MyCompany")]
        public int CompanyId { get; set; }
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(d=>d.AllProducts)
                .WithOptional(l=>l.MyBrand).WillCascadeOnDelete(false);


        }

        //public System.Data.Entity.DbSet<SNOW_Solution.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}