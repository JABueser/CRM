using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class HourViewModel
    {
        public List<Volunteer> Vols { get; set; }
        public Volunteer VolunteerPerson { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public int VolID { get; set; }
        public int CatName { get; set; }

    }
}