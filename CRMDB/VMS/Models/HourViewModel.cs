using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VMS.Models
{
    public class HourViewModel
    {
        public List<Volunteer> Vols { get; set; }
        public int VolID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Category> Categories { get; set; }
        public string Church { get; set; }
        public string DateCreated { get; set; }
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        [DefaultValue(0)]
        public int Hours { get; set; }
        public int CatName { get; set; }
        public List<CategoryFilter> CatFilter { get; set; }

        public static CategoryFilter Create(Category c)
        {
            return new CategoryFilter
            {
                CategoryID = c.CategoryID,
                CategoryName = c.Category1,
                isSelected = false
            };
        }
    }

    public class CategoryFilter
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool isSelected { get; set; }
    }
}