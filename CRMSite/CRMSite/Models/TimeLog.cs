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
    
    public partial class TimeLog
    {
        public int TimeLogID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> HoursWorked { get; set; }
        public int CategoryID { get; set; }
        public int VolunteerID { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Volunteer Volunteer { get; set; }
    }
}
