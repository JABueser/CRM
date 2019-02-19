using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class CreateViewModel
    {
        public List<int> SelectedCategories { get; set; }
        public List<int> SelectedDays { get; set; }
        public List<Category> AllCategories { get; set; }
        public List<Availability> AllAvailability { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public DateTime BirthDate { get; set; }
        public string Organization { get; set; }
        public string Occupation { get; set; }
        public string Church { get; set; }
        public string Pastor { get; set; }
        public string HowDidYouHear { get; set; }
        public string Felony { get; set; }
        public string NatureOfFelony { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyRelation { get; set; }
        public string EmergencyPhone { get; set; }
        public string Disabilities { get; set; }
        public string Skills { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}