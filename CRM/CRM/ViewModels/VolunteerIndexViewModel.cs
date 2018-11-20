using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.ViewModels
{
    public class VolunteerIndexViewModel
    {
        public IEnumerable<Volunteer> Volunteers { get; set; }
    }
}
