using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using VMS.Models;

[assembly: OwinStartupAttribute(typeof(VMS.Startup))]
namespace VMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        //In this method we will create default User roles and Admin user for login
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup I am creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin role  
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser
                {
                    UserName = "VMSAdmin@email.com",
                    Email = "VMSAdmin@email.com",
                    FullName = "Orvin Feliciano"
                };

                string userPWD = "P@ssw0rd";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };
                roleManager.Create(role);

            }
        }
    }
}

