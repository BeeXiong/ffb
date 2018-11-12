using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using FantasyFootballPlayoffs.Models;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using System;
using System.Configuration;
using FantasyFootballPlayoffs.DAL;

namespace FantasyFootballPlayoffs.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class FantasyDbContext : IdentityDbContext<User>
    {
        public virtual DbSet<fantasy_League> fantasy_Leagues { get; set; }
        public virtual DbSet<fantasy_League_Detail> fantasy_League_Details { get; set; }
        public virtual DbSet<fantasy_Owner> fantasy_Owners { get; set; }
        public virtual DbSet<fantasy_Roster> fantasy_Rosters { get; set; }
        public virtual DbSet<fantasy_Team> fantasy_Teams { get; set; }
        public virtual DbSet<game> games { get; set; }
        public virtual DbSet<stat> stats { get; set; }
        public virtual DbSet<location> locations { get; set; }
        public virtual DbSet<playerPosition> playerPositions { get; set; }
        public virtual DbSet<player> players { get; set; }
        public virtual DbSet<sport> sports { get; set; }
        public virtual DbSet<statisticalCategory> statisticalCategories { get; set; }
        public virtual DbSet<homeTeam> homeTeams { get; set; }
        public virtual DbSet<awayTeam> awayTeams { get; set; }
        public virtual DbSet<fantasy_Player_Slot> fantasy_Player_Slots { get; set; }
        public virtual DbSet<zRawNFLRoster> zRawNFLRosters { get; set; }
        public virtual DbSet<playoffRound> playoffRounds { get; set; }
        public virtual DbSet<playoffTeam> playoffTeams { get; set; }
        public virtual DbSet<conference> conferences { get; set; }
        public virtual DbSet<currentYear> currentYears { get; set; }
        public virtual DbSet<calendarYear> calendarYears { get; set; }
        //development environment using local DB
        //public FantasyDbContext()
        //    : base("FantasyDatabase", throwIfV1Schema: false)
        //{
        //}
        //public static FantasyDbContext Create()
        //{
        //    return new FantasyDbContext();
        //}

        //development environment using remote DB
        public FantasyDbContext()
            : base(GetRDSConnectionString(), throwIfV1Schema: false)
        {

        }

        public static FantasyDbContext Create()
        {
            return new FantasyDbContext();
        }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim").Property(p => p.Id).HasColumnName("UserClaimId");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").Property(p => p.Id).HasColumnName("RoleId");
        }
        private static string GetRDSConnectionString()
        {
            //add try catch to gett parameter from AWS paramater store and inject to the new DBContext
            string connectionString = "";
            string configEnvironment = ConfigurationManager.AppSettings["configEnvironment"];
            string parameterName = ConfigurationManager.AppSettings["connectionString"];

            if (configEnvironment == "dev")
            {
                connectionString = parameterFactory.getDevParameter(parameterName);
            }
            else if (configEnvironment == "prod")
            {
                connectionString = parameterFactory.getProdParameter(parameterName);
            }
            return connectionString;
        }

    }

}