using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Volunteer
    {
        public int volunteerID { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Please enter your address")]
        public string address { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        public string city { get; set; }
        [Required(ErrorMessage = "Please enter your state")]
        public string state { get; set; }
        [Required(ErrorMessage = "Please enter your zipcode")]
        public int zipCode { get; set; }
        [Required(ErrorMessage = "Please enter your birthdate")]
        public string birthDate { get; set; }
        [Required(ErrorMessage = "Please enter your organization")]
        public string organization { get; set; }
        [Required(ErrorMessage = "Please enter your occupation")]
        public string occupation { get; set; }
        [Required(ErrorMessage = "Please enter your church affiliation")]
        public string church { get; set; }
        [Required(ErrorMessage = "Please enter your senior pastor")]
        public string pastor { get; set; }
        [Required(ErrorMessage = "Please enter how you heard about us")]
        public string howDidYouHear { get; set; }
        [Required(ErrorMessage = "Please enter your felony status")]
        public string felony { get; set; }
        [Required(ErrorMessage = "Please enter your nature of feleony")]
        public string natureOfFelony { get; set; }
        [Required(ErrorMessage = "Please enter your emergency contact's name")]
        public string emergencyName { get; set; }
        [Required(ErrorMessage = "Please enter your emergency contact's relation")]
        public string emergencyRelation { get; set; }
        [Required(ErrorMessage = "Please enter your emergency contact's phone number")]
        public string emergencyPhone { get; set; }
        [Required(ErrorMessage = "Please enter any possible issues")]
        public string disabilities { get; set; }
        [Required(ErrorMessage = "Please select your availabilities")]
        public string availability { get; set; }
        [Required(ErrorMessage = "Please enter your skill set")]
        public string skills { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Please select your interests")]
        public string interest { get; set; }
        public int hours { get; set; }
    }
}
