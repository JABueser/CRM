using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMSite.Models;

namespace CRMSite.Controllers
{
    public class VolunteersController : Controller
    {
        private CRMDBEntities db = new CRMDBEntities();

        // GET: Volunteers
        public ActionResult Index()
        {
            var model = new FilterViewModel
            {
                AllCategories = db.Categories.ToList(),
                Volunteers = db.Volunteers.ToList()
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult FilterVolunteers(string CategoryID)
        {
            if(CategoryID == "")
            {
                return PartialView("_VolunteerList", db.Volunteers.ToList());
            }
            int ID = Convert.ToInt32(CategoryID);
            List<Volunteer> filteredVolunteers = new List<Volunteer>();
            List<Volunteer> volunteers = db.Volunteers.ToList();
            foreach (var v in volunteers)
            {
                foreach (var c in v.Categories)
                {
                    if (c.CategoryID == ID)
                    {
                        filteredVolunteers.Add(v);
                    }
                }
            }
           
            return PartialView("_VolunteerList", filteredVolunteers);
        }

        // GET: Volunteers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // GET: Volunteers/Create
        public ActionResult Create()
        {
            List<Category> AllCats = db.Categories.ToList();
            List<Availability> AllDays = db.Availabilities.ToList();

            var model = new CreateViewModel
            {
                AllCategories = AllCats,
                AllAvailability = AllDays
            };

            return View(model);
        }

        // POST: Volunteers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel postModel)
        {
            var volunteer = new Volunteer
            {
                LastName = postModel.LastName,
                FirstName = postModel.FirstName,
                Address = postModel.Address,
                City = postModel.City,
                State = postModel.State,
                Zipcode = postModel.Zipcode,
                BirthDate = postModel.BirthDate,
                Organization = postModel.Organization,
                Occupation = postModel.Occupation,
                Church = postModel.Church,
                Pastor = postModel.Pastor,
                HowDidYouHear = postModel.HowDidYouHear,
                Felony = postModel.Felony,
                NatureOfFelony = postModel.NatureOfFelony,
                EmergencyName = postModel.EmergencyName,
                EmergencyPhone = postModel.EmergencyPhone,
                EmergencyRelation = postModel.EmergencyRelation,
                Disabilities = postModel.Disabilities,
                Skills = postModel.Skills,
                Email = postModel.Email,
                Phone = postModel.Phone
            };

            db.Volunteers.Add(volunteer);



            foreach (var d in postModel.SelectedDays)
            {
                var avail = new Availability
                {
                    AvailabilityID = d
                };

                db.Availabilities.Add(avail);
                db.Availabilities.Attach(avail);

                avail.Volunteers.Add(volunteer);
            }

            foreach (var c in postModel.SelectedCategories)
            {
                var cat = new Category
                {
                    CategoryID = c
                };

                db.Categories.Add(cat);
                db.Categories.Attach(cat);

                cat.Volunteers.Add(volunteer);
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Volunteers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VolunteerID,LastName,FirstName,Address,City,State,Zipcode,BirthDate,Organization,Occupation,Church,Pastor,HowDidYouHear,Felony,NatureOfFelony,EmergencyName,EmergencyRelation,EmergencyPhone,Disabilities,Skills,Email,Phone,TotalHours")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volunteer);
        }

        // GET: Volunteers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volunteer volunteer = db.Volunteers.Find(id);
            db.Volunteers.Remove(volunteer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
