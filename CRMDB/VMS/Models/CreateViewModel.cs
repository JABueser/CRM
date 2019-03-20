using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Address { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }
       
        public string Organization { get; set; }
       
        public string Occupation { get; set; }
        
        public string Church { get; set; }
       
        public string Pastor { get; set; }
        
        public string HowDidYouHear { get; set; }
        [Required]
        public string Felony { get; set; }
        [Required]
        public string NatureOfFelony { get; set; }
        [Required]
        public string EmergencyName { get; set; }
        [Required]
        public string EmergencyRelation { get; set; }
        [Required]
        public string EmergencyPhone { get; set; }
        
        public string Disabilities { get; set; }
        
        public string Skills { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}