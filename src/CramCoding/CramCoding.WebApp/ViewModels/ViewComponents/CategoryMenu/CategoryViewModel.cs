using System.Collections.Generic;

namespace CramCoding.WebApp.ViewModels.ViewComponents.CategoryMenu
{
    public class MenuCategoryViewModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<string> Subcategories { get; set; }
    }
}
