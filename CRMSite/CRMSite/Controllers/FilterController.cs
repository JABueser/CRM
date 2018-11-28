using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMSite.Models;

namespace CRMSite.Controllers
{
    public class FilterController : Controller
    {
        private CRMDBEntities db = new CRMDBEntities();

        // GET: Filter
        public ActionResult Index()
        {
            List<Category> AllCats = db.Categories.ToList();
            List<Volunteer> Volun = db.Volunteers.ToList();

            var model = new FilterViewModel
            {
                AllCategories = AllCats,
                Volunteers = Volun
            };

            return View(model);
        }


    }
}