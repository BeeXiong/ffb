using Microsoft.Owin;
using Owin;
using FantasyFootballPlayoffs.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;


[assembly: OwinStartupAttribute(typeof(FantasyFootballPlayoffs.Startup))]
namespace FantasyFootballPlayoffs
{
    public partial class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
            // Enables the application to use SignalR for live draft feature
            app.MapSignalR();
        }
        private void createRolesandUsers()
        {
            FantasyDbContext context = new FantasyDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));


            // In Startup I am creating first Admin Role and creating a default Admin User   
            if (UserManager.FindByName("bee.xiong") == null)
            {
                //UserManager.FindByName() == null 
                // first we create Admin role   
                //var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                //role.Name = "Admin";
                //roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                 

                var user = new User();
                user.UserName = "bee.xiong";
                user.Email = "beexiong64@gmail.com";

                string userPWD = "(TGbv6450)";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin  
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "1");

                }
            }
        }
    }
}
