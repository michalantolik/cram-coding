using System.ComponentModel.DataAnnotations;

namespace CramCoding.WebApp.ViewModels.Admin.Tag
{
    public class EditTagViewModel
    {
        [Required(ErrorMessage = "Fill in tag name")]
        [Display(Name = "Name")]
        public string TagName { get; set; }
    }
}
