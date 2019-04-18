﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VMS.Models;

namespace VMS.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class VolunteersController : Controller
    {

        private CRMDBEntities db = new CRMDBEntities();


        // GET: Volunteers
        //test
        public ActionResult Index()
        {
            var HoursViewModel = new HourViewModel
            {
                Vols = db.Volunteers.ToList(),
                Categories = db.Categories.ToList()
                
            };
            return View(HoursViewModel);
        }


        [HttpPost]
        public ActionResult Index(HourViewModel postModel)
        {
            List<Category> AllCats = db.Categories.ToList();

            Volunteer a = db.Volunteers.FirstOrDefault(t => t.VolunteerID == postModel.VolID);

            if (a != null)
            {
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

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult HoursForm()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult HoursForm(ViewHourViewModel model)
        {
            return RedirectToAction("HourSummary", model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult HourSummary(ViewHourViewModel model)
        {
            var start = model.StartDate;
            var end = model.EndDate;
            List<TimeLog> time;
            if(start == null && end == null)
            {
                time = db.TimeLogs.ToList();
            }
            else if (start == null && end != null)
            {
                time = db.TimeLogs.Where(
                e => e.Date <= end).ToList();
            }
            else if(start != null && end == null)
            {
                time = db.TimeLogs.Where(
                e => e.Date >= start).ToList();
            }
            else
            {
                time = db.TimeLogs.Where(
                e=> e.Date  >= start && e.Date <= end).ToList();
            }
        

            model.Doctor = 0;
            model.Dentist = 0;
            model.Auto = 0;
            model.Nurse = 0;
            model.Ministry = 0;
            model.Bus = 0;
            model.Office = 0;
            model.Maintenance = 0;
            model.Auto = 0;
            model.Food = 0;
            model.Men = 0;
            model.Thrift = 0;
            model.Special = 0;
            model.Women = 0;
            model.Training = 0;
            model.Service = 0;
            model.Total = 0;

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
                if (t.Category.Category1.Equals("Community Service"))
                {
                    model.Service = model.Service + (int)t.HoursWorked;
                }

                model.Total = model.Total + (int)t.HoursWorked;
            }

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

        [HttpPost]
        public ActionResult Details(int volid, int timeid)
        {
            if (timeid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TimeLog timelog = db.TimeLogs.Find(timeid);
            Volunteer volunteer = db.Volunteers.Find(volid);
            volunteer.TotalHours = volunteer.TotalHours - timelog.HoursWorked;
            db.Entry(volunteer).State = EntityState.Modified;
            db.TimeLogs.Remove(timelog);
            db.SaveChanges();

            if (volunteer == null)
            {
                return HttpNotFound();
            }

            return View(volunteer);
        }

        [AllowAnonymous]
        // GET: Volunteers/Create
        [HttpGet]
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

        [AllowAnonymous]
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
                Address2 = postModel.Address2,
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
                Phone = postModel.Phone,
                DateCreated = DateTime.Now,
                TotalHours = 0
            };

            db.Volunteers.Add(volunteer);

            foreach (var d in postModel.SelectedDays)
            {
                InsertVolunteerAvail(volunteer, d);
            }

            foreach (var c in postModel.SelectedCategories)
            {
                InsertVolunteerCat(volunteer, c);
            }

            return View("ThankYou");
        }

        // GET: Volunteers/Edit/5
        public ActionResult Edit(int? id)
        {
            Volunteer vol = db.Volunteers.Find(id);
            List<Category> AllCats = db.Categories.ToList();
            List<Availability> AllDays = db.Availabilities.ToList();
            List<int> SelectCats = new List<int>();
            List<int> SelectDays = new List<int>();

            foreach (var c in db.Volunteers.Find(id).Categories)
            {
                SelectCats.Add(c.CategoryID);
            }

            foreach (var d in db.Volunteers.Find(id).Availabilities)
            {
                SelectDays.Add(d.AvailabilityID);
            }

            var model = new EditViewModel
            {
                AllCategories = AllCats,
                AllAvailability = AllDays,
                SelectedCategories = SelectCats,
                SelectedDays = SelectDays,
                PreviousCategories = SelectCats,
                PreviousDays = SelectDays,
                VolunteerPerson = vol
            };

            return View(model);
        }

        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel postModel)
        {
            if (ModelState.IsValid)
            {
                List<Category> AllCats = db.Categories.ToList();
                List<Availability> AllDays = db.Availabilities.ToList();
                Volunteer volunteer = db.Volunteers.Find(postModel.VolunteerPerson.VolunteerID);
                //Volunteer volunteer = db.Volunteers.Include(t => t.Categories).Single(u => u.VolunteerID == postModel.VolunteerPerson.VolunteerID);

                volunteer.LastName = postModel.VolunteerPerson.LastName;
                volunteer.FirstName = postModel.VolunteerPerson.FirstName;
                volunteer.Address = postModel.VolunteerPerson.Address;
                volunteer.Address2 = postModel.VolunteerPerson.Address2;
                volunteer.City = postModel.VolunteerPerson.City;
                volunteer.State = postModel.VolunteerPerson.State;
                volunteer.Zipcode = postModel.VolunteerPerson.Zipcode;
                volunteer.BirthDate = postModel.VolunteerPerson.BirthDate;
                volunteer.Organization = postModel.VolunteerPerson.Organization;
                volunteer.Occupation = postModel.VolunteerPerson.Occupation;
                volunteer.Church = postModel.VolunteerPerson.Church;
                volunteer.Pastor = postModel.VolunteerPerson.Pastor;
                volunteer.HowDidYouHear = postModel.VolunteerPerson.HowDidYouHear;
                volunteer.Felony = postModel.VolunteerPerson.Felony;
                volunteer.NatureOfFelony = postModel.VolunteerPerson.NatureOfFelony;
                volunteer.EmergencyName = postModel.VolunteerPerson.EmergencyName;
                volunteer.EmergencyPhone = postModel.VolunteerPerson.EmergencyPhone;
                volunteer.EmergencyRelation = postModel.VolunteerPerson.EmergencyRelation;
                volunteer.Disabilities = postModel.VolunteerPerson.Disabilities;
                volunteer.Skills = postModel.VolunteerPerson.Skills;
                volunteer.Email = postModel.VolunteerPerson.Email;
                volunteer.Phone = postModel.VolunteerPerson.Phone;

                foreach (var d in AllDays)
                {
                    if (d.Volunteers.Contains(volunteer))
                    {
                        DeleteVolunteerAvail(volunteer, d.AvailabilityID);
                    }
                }

                foreach (var c in AllCats)
                {
                    if (c.Volunteers.Contains(volunteer))
                    {
                        DeleteVolunteerCat(volunteer, c.CategoryID);
                    }
                }

                if (postModel.SelectedDays != null)
                {
                    foreach (var d in postModel.SelectedDays)
                    {
                        UpdateVolunteerAvail(volunteer, d);
                    }
                }

                if (postModel.SelectedCategories != null)
                {
                    foreach (var c in postModel.SelectedCategories)
                    {
                        UpdateVolunteerCat(volunteer, c);
                    }
                }

                db.Entry(volunteer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postModel);
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

        public void InsertVolunteerAvail(Volunteer volunteer, int availabilityID)
        {
            Availability a = new Availability { AvailabilityID = availabilityID };

            db.Availabilities.Add(a);
            db.Availabilities.Attach(a);

            a.Volunteers.Add(volunteer);

            db.SaveChanges();
        }

        public void InsertVolunteerCat(Volunteer volunteer, int catID)
        {
            Category c = new Category { CategoryID = catID };

            db.Categories.Add(c);
            db.Categories.Attach(c);

            c.Volunteers.Add(volunteer);

            db.SaveChanges();
        }

        public void UpdateVolunteerAvail(Volunteer volunteer, int availabilityID)
        {
            Availability a = db.Availabilities.FirstOrDefault(t => t.AvailabilityID == availabilityID);

            a.Volunteers.Add(volunteer);

            db.SaveChanges();
        }

        public void UpdateVolunteerCat(Volunteer volunteer, int catID)
        {
            Category c = db.Categories.FirstOrDefault(t => t.CategoryID == catID);

            c.Volunteers.Add(volunteer);

            db.SaveChanges();
        }

        public void DeleteVolunteerAvail(Volunteer volunteer, int availabilityID)
        {
            var avail = db.Availabilities.FirstOrDefault(a => a.AvailabilityID == availabilityID);

            avail.Volunteers.Remove(volunteer);

            db.SaveChanges();
        }

        public void DeleteVolunteerCat(Volunteer volunteer, int catID)
        {
            var cat = db.Categories.FirstOrDefault(c => c.CategoryID == catID);

            cat.Volunteers.Remove(volunteer);

            db.SaveChanges();
        }

    }
}