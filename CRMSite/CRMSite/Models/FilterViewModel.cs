using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMSite.Models
{
    public class FilterViewModel
    {
        public IEnumerable<Category> AllCategories { get; set; }

        public string SelectedCategoryId { get; set; }

        public IEnumerable<Volunteer> Volunteers { get; set; }
    }
}