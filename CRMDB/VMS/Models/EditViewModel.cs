using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class EditViewModel
    {
        public List<int> SelectedCategories { get; set; }
        public List<int> SelectedDays { get; set; }
        public List<int> PreviousCategories { get; set; }
        public List<int> PreviousDays { get; set; }
        public List<Category> AllCategories { get; set; }
        public List<Availability> AllAvailability { get; set; }
        public Volunteer VolunteerPerson { get; set; }
        public string State { get; set; }
    }
}