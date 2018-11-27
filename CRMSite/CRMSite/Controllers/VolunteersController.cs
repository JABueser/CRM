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
            List<Category> AllCats = db.Categories.ToList();

            var model = new HourViewModel
            {
                Vols = db.Volunteers.ToList()
            };


            return View(model);
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

        public ActionResult HourSummary()
        {
            List<TimeLog> time = db.TimeLogs.ToList();

            var model = new ViewHourViewModel
            {
                Doctor = 0,
                Dentist = 0,
                Nurse = 0,
                Ministry = 0,
                Bus = 0,
                Office = 0,
                Maintenance = 0,
                Auto = 0,
                Food = 0,
                Men = 0,
                Thrift = 0,
                Special = 0,
                Women = 0,
                Training = 0,
                Total = 0
            };

            foreach (var t in time)
            {
                if (t.Category.Category1.Equals("Doctor"))
                {
                    model.Doctor = model.Doctor + (int)t.HoursWorked;
                }
                if (t.Category.Category1.Equals("Dentist"))
                {
                    model.Dentist = model.Dentist + (int)t.HoursWorked;
                }
                if (t.Category.Category1.Equals("Nurse"))
                {
                    model.Nurse = model.Nurse + (int)t.HoursWorked;
                }
                if (t.Category.Category1.Equals("Chapel Ministry"))
                {
                    model.Ministry = model.Ministry + (int)t.HoursWorked;
                }
                if (t.Category.Category1.Equals("Bus Driver"))
                {
                    model.Bus = model.Bus + (int)t.HoursWorked;
                }
                if (t.Category.Category1.Equals("Office/Clerical"))
                {
                    model.Office = model.Office + (int)t.HoursWorked;
                }
                if (t.Category.Category1.Equals("Maintenance"))
                {
                    model.Maintenance = model.Maintenance + (int)t.HoursWorked;
                }
                if (t.Category.Category1.Equals("Auto Shop"))
                {
                    model.Auto = model.Auto + (int)t.HoursWorked;
                }
                if (t.Category.Category1.Equals("Mens Division"))
                {
                    model.Men = model.Men + (int)t.HoursWorked;
                }
                if (t.Category.Category1.Equals("Thrift Store"))
                {
                    model.Thrift = model.Thrift + (int)t.HoursWorked;
                }
                if (t.Category.Category1.Equals("Special Events"))
                {
                    model.Special = model.Special + (int)t.HoursWorked;
                }
                if (t.Category.Category1.Equals("Women, Children, and Families"))
                {
                    model.Women = model.Women + (int)t.HoursWorked;
                }
                if (t.Category.Category1.Equals("Job Training/Life Skills Instructor"))
                {
                    model.Training = model.Training + (int)t.HoursWorked;
                }

                model.Total = model.Total + (int)t.HoursWorked;
            }

            return View(model);

        }
        [HttpPost]
        public ActionResult Index(HourViewModel postModel)
        {
            List<Category> AllCats = db.Categories.ToList();

            Volunteer a = db.Volunteers.FirstOrDefault(t => t.VolunteerID == postModel.VolID);


            a.TotalHours = a.TotalHours + postModel.Hours;

            var model = new TimeLog
            {
                Date = postModel.Date,
                HoursWorked = postModel.Hours,
                VolunteerID = postModel.VolID,
                CategoryID = postModel.CatName
            };

            db.Entry(a).State = EntityState.Modified;
            db.TimeLogs.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
