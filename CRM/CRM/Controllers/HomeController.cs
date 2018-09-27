using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult VolunteerForm()
        {
            return View();
        }

        public ViewResult VolunteerHours()
        {
            return View();
        }

        public ViewResult VolunteerEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VolunteerOutput(string first, string last, string phone, string email)
        {
            return Content($"First Name: {first} \nLast Name: {last} \nPhone Number: {phone} \nEmail: {email}");
        }


    }
}
