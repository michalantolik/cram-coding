using System.ComponentModel.DataAnnotations;

namespace CramCoding.WebApp.ViewModels.Admin.Category
{
    public class EditCategoryViewModel
    {
        [Required(ErrorMessage = "Fill in category name")]
        [Display(Name = "Name")]
        public string CategoryName { get; set; }
    }
}
