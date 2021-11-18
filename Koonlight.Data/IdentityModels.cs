using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Koonlight.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Koonlight.MVC.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName { get; set; }
        [Required]
        public int DLN { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public int PickUpNum { get; set; }
        [Required]
        public int Phone { get; set; }
        public string SCAC { get; set; }
        public bool Currently { get; set; }
        public EndorsementEnum SpecialLicense { get; set; }
        public bool IsInsured { get; set; }
        //Current Location (stretch goal)
        //QR Code (stretch goal)
        //CDL Restrictions (stretch goal)
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public enum EndorsementEnum
    {
        Hazmat = 1, 
        Tanker, 
        Multiple_Trailers,
        Hazmat_Tank

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Load> Loads { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
    }
}