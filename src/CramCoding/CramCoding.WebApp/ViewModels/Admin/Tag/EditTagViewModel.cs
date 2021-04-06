using System.ComponentModel.DataAnnotations;

namespace CramCoding.WebApp.ViewModels.Admin.Tag
{
    public class EditTagViewModel
    {
        [Required(ErrorMessage = "Uzupełnij nazwę")]
        [Display(Name = "Nazwa")]
        public string TagName { get; set; }
    }
}
