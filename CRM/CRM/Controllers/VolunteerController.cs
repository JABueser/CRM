using CRM.Models;
using CRM.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly IVolunteerService _volunteerService;

        public VolunteerController(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }


        public async Task<IActionResult> Index()
        {
            var volunteers = await _volunteerService.GetIncompleteVolunteersAsync();

            var model = new VolunteerViewModel()
            {
                Volunteers = volunteers
            };
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> FilterVolunteers(string interest)
        { 
            var volunteers = await _volunteerService.GetIncompleteVolunteersAsync();

            var model = new VolunteerViewModel()
            {
                Volunteers = volunteers.Where(i => (i.interest == interest)).Cast<Volunteer>().ToArray()
            };
            return PartialView("_VolunteerList", model);
        }
    }
}
