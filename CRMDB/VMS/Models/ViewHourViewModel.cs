using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class ViewHourViewModel
    {
        public int Doctor { get; set; }
        public int Dentist { get; set; }
        public int Nurse { get; set; }
        public int Ministry { get; set; }
        public int Bus { get; set; }
        public int Office { get; set; }
        public int Maintenance { get; set; }
        public int Auto { get; set; }
        public int Food { get; set; }
        public int Men { get; set; }
        public int Thrift { get; set; }
        public int Special { get; set; }
        public int Women { get; set; }
        public int Training { get; set; }
        public int Total { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}