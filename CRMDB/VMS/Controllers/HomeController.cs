using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMS.Models;

namespace VMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //depreciated
        public ActionResult GetData()
        {
            using (CRMDBEntities db = new CRMDBEntities())
            {
                List<Volunteer> vols = db.Volunteers.ToList();
                List<TestViewModel> model = new List<TestViewModel>();
                foreach (Volunteer volunteer in vols)
                {
                    int hours = 0;
                    hours = (int)volunteer.TotalHours;
                    
                    List<string> categories = new List<string>();
                    foreach (Category c in volunteer.Categories)
                    {
                        categories.Add(c.Category1);
                    }
                    model.Add(
                        new TestViewModel()
                        {
                            DateCreated = volunteer.DateCreated.ToShortDateString(),
                            VolID = volunteer.VolunteerID,
                            FirstName = volunteer.FirstName,
                            LastName = volunteer.LastName,
                            Email = volunteer.Email,
                            Categories = categories,
                            Church = volunteer.Church,
                            Hours = hours
                        }
                    );
                }
                return Json(new { data = model }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}