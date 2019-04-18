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
                              select new ApplicationUser
                              {
                                  Id = user.Id,
                                  FullName = user.FullName,
                                  UserName = user.UserName,
                                  Email = user.Email,
                                  RoleNames = (from userRole in user.Roles
                                               join role in context.Roles on userRole.RoleId
                                               equals role.Id
                                               select role.Name).ToList()
                              }).ToList().Select(u =>
                                  UserViewModel.Create(u, context.Roles.OrderBy(x => x.Name).ToList()));
                                  
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
                var model = UserViewModel.Create(user, context.Roles.OrderBy(x => x.Name).ToList());
                //{
                //    FullName = user.FullName,
                //    Email = user.Email,
                //    Role = string.Join(",", (),
                //    RolesList = context.Roles.OrderBy(x => x.Name)
                //};
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