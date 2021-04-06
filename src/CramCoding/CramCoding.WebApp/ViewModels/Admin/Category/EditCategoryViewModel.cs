using System.ComponentModel.DataAnnotations;

namespace CramCoding.WebApp.ViewModels.Admin.Category
{
    public class EditCategoryViewModel
    {
        [Required(ErrorMessage = "Uzupełnij nazwę")]
        [Display(Name = "Nazwa")]
        public string CategoryName { get; set; }
    }
}
