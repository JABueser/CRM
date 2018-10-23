using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models
{
    public class Volunteer
    {
        public int volunteerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
        public string birthDate { get; set; }
        public string organization { get; set; }
        public string occupation { get; set; }
        public string church { get; set; }
        public string pastor { get; set; }
        public string howDidYouHear { get; set; }
        public string felony { get; set; }
        public string natureOfFelony { get; set; }
        public string emergencyName { get; set; }
        public string emergencyRelation { get; set; }
        public string emergencyPhone { get; set; }
        public string disabilities { get; set; }
        public string availability { get; set; }
        public string skills { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string interest { get; set; }
        public int hours { get; set; }
    }
}
