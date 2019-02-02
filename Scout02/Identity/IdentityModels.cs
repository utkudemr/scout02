using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.Entity;
using Scout02.Entity;

namespace Scout02.Models
{
    // ApplicationUser sınıfınıza daha fazla özellik ekleyerek kullanıcıya profil verileri ekleyebilirsiniz. Daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkID=317594 adresini ziyaret edin.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // authenticationType özelliğinin CookieAuthenticationOptions.AuthenticationType içinde tanımlanmış olanla eşleşmesi gerektiğini unutmayın
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Özel kullanıcı taleplerini buraya ekle
            return userIdentity;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? RegisterDate { get; set; }
        public DateTime? Birthday { get; set; }
        public bool Gender { get; set; }
        public virtual UserContact UserContact { get; set; }
        public virtual UserImages UserImages { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName):base(roleName)
        {

        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("ScoutDbConStr", throwIfV1Schema: false)
        {
        }

        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<FootballerImage> FootballersImages { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Coaching> Coachings { get; set; }
        public DbSet<Leauge> Leauges { get; set; }
        public DbSet<Country> Countries { get; set; }


        public DbSet<UserContact> UserContact { get; set; }
        public DbSet<UserSocialAccounts> UserSocialAccounts { get; set; }
        public DbSet<UserAddresses> UserAddresses { get; set; }
        public DbSet<UserPostsLike> UserPostsLikes { get; set; }
        public DbSet<UserPosts> UserPosts { get; set; }
        public DbSet<UserPostPoint> UserPostPoints { get; set; }
        public DbSet<PhysicalAttributes> PhysicalAttributes { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<UserImages> UserImage { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Scout02.Identity.RoleViewModel> RoleViewModels { get; set; }
        public object ApplicationUser { get; internal set; }

    
    }
}