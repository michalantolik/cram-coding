using System.ComponentModel.DataAnnotations;

namespace CramCoding.WebApp.ViewModels.Admin.Tag
{
    public class EditTagViewModel
    {
        [Required(ErrorMessage = "Fill in tag name")]
        [Display(Name = "Name")]
        public string TagName { get; set; }

        /// <summary>
        /// Name of a controller which should be used when category is submitted
        /// </summary>
        public string SubmitController { get; set; }

        /// <summary>
        /// Name of a action method which should be used when category is submitted
        /// </summary>
        public string SubmitAction { get; set; }
    }
}
