using System.Collections.Generic;

namespace CramCoding.WebApp.ViewModels
{
    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<string> Subcategories { get; set; }
    }
}
