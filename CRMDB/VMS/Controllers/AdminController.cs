using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VMS.Models;

namespace VMS.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext context;
        public AdminController()
        {
            context = new ApplicationDbContext();
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            var viewModels = (from user in context.Users
                              select new
                              {
                                  Id = user.Id,
                                  FullName = user.FullName,
                                  Username = user.UserName,
                                  Email = user.Email,
                                  RoleNames = (from userRole in user.Roles
                                               join role in context.Roles on userRole.RoleId
                                               equals role.Id
                                               select role.Name).ToList()
                              }).ToList().Select(u =>
                                  new UserViewModel
                                  {
                                      Id = u.Id,
                                      FullName = u.FullName,
                                      UserName = u.Username,
                                      Role = string.Join(",", u.RoleNames),
                                      Email = new String(u.Email.Where(Char.IsLetter).ToArray()),
                                      RolesList = context.Roles.OrderBy(x => x.Name)
                                  });
            return View(viewModels);
        }

        [HttpPost]
        public async Task<ActionResult> Index(UserViewModel postModel)
        {
            var user = await UserManager.FindByNameAsync(postModel.UserName);

            //get user's assigned roles
            IList<string> userRoles = await UserManager.GetRolesAsync(user.Id);
            
            //check for role to be removed
            var roleToAdd = userRoles.FirstOrDefault(role => role.Equals(postModel.Role, StringComparison.InvariantCultureIgnoreCase));
            if (roleToAdd == postModel.Role)
            {
                //I am already in that role
                return RedirectToAction("Index");
            }
            else
            {
                //I did not find the role, I must remove all the roles and then add my own.
     
                foreach(string role in userRoles)
                {
                     await UserManager.RemoveFromRoleAsync(user.Id, role);
                }
                var result = await UserManager.AddToRoleAsync(user.Id, postModel.Role);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(string name)
        {
            var user = await UserManager.FindByNameAsync(name);
            if(user != null)
            {
                var model = new UserViewModel()
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = string.Join(",", (from userRole in user.Roles
                                             join role in context.Roles on userRole.RoleId
                                             equals role.Id
                                             select role.Name)),
                    RolesList = context.Roles.OrderBy(x => x.Name)
                };
                return View(model);
            }
            return View("Error");
            
        }

        //[HttpPost]
        //public async Task<ActionResult> DetailsAsync(string name, string role)
        //{
        //    var user = await UserManager.FindByNameAsync(name);
        //    return View(user);
        //}
    }
}