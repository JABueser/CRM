using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.JdModelExample;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public partial class CheckboxController : Controller
    {
        private readonly List<Category> AllCats;

        public CheckboxController()
        {
            //doing this in the constructor because it's just an example.
            //this would be pulled from db in your app
            AllCats = new List<Category>()
            {
                new Category { Id = 1, Name = "Cat 1"},
                new Category { Id = 2, Name = "Cat 2"},
                new Category { Id = 3, Name = "Cat 3"},
                new Category { Id = 4, Name = "Cat 4"},
                new Category { Id = 5, Name = "Cat 5"},
            };
        }

        public IActionResult Index()
        {
            var model = new CheckBoxVm
            {
                AllCategories = AllCats,  //get them all so you can display every cat on the page
                SelectedCategories = new List<int>() { 1, 3, 5 } //load only the ones the usre selected
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CheckBoxVm postModel)
        {
            //john, set a breakpoint here and inspect the postModel.SelectedCategories
            throw new NotImplementedException();
        }
        
    }
}