
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public IEnumerable<IdentityRole> RolesList { get; set; }

        public static UserViewModel Create(ApplicationUser u, List<IdentityRole> roles)
        {
            return new UserViewModel
            {   
                Id = u.Id,
                FullName = u.FullName,
                UserName = u.UserName,
                Role = string.Join(",", u.RoleNames),
                Email = new String(u.Email.Where(Char.IsLetter).ToArray()),
                RolesList = roles
            };
        }   
    }
}

