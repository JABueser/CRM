using CRM.Models;
using CRM.Services;
using CRM.ViewModels;
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
        private readonly IVolunteerData _volunteerData;

        public VolunteerController(IVolunteerService volunteerService, IVolunteerData volunteerData)
        {
            _volunteerService = volunteerService;
            _volunteerData = volunteerData;
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

        public IActionResult List()
        {
            var model = new VolunteerIndexViewModel();
            model.Volunteers = _volunteerData.GetAll();
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
