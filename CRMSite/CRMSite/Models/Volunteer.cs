//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRMSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Volunteer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Volunteer()
        {
            this.TimeLogs = new HashSet<TimeLog>();
            this.Availabilities = new HashSet<Availability>();
            this.Categories = new HashSet<Category>();
            this.TotalHours = 0;
        }
    
        public int VolunteerID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string BirthDate { get; set; }
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
        public Nullable<int> TotalHours { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeLog> TimeLogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Availability> Availabilities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}
