using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRM.Models;

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

        [HttpGet]
        public ViewResult VolunteerForm()
        {
            return View();
        }

        public ViewResult VolunteerHours()
        {
            return View();
        }

        public ViewResult ListVolunteer()
        {
            return View(Repository.Volunteers);
        }

        [HttpPost]
        public ViewResult VolunteerConfirm(Volunteer volunteer)
        {
            Repository.AddVolunteer(volunteer);
            return View("Confirm", volunteer);
        }

        public ViewResult VolunteerInterest()
        {
            return View(Repository.Volunteers);
        }

    }
}
