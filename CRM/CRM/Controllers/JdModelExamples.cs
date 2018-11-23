using System.Collections.Generic;

namespace CRM.JdModelExample
{
    public class CheckBoxVm
    {
        public List<Category> AllCategories { get; set; }
        public List<int> SelectedCategories { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}