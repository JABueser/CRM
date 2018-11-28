using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSite.Models
{
    public class FilterViewModel
    {
        public IEnumerable<Category> AllCategories { get; set; }

        public string SelectedCategoryID { get; set; }

        public IEnumerable<Volunteer> Volunteers { get; set; }
    }
}