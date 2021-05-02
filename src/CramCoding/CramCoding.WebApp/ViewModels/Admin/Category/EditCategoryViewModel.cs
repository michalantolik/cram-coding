using System.ComponentModel.DataAnnotations;

namespace CramCoding.WebApp.ViewModels.Admin.Category
{
    public class EditCategoryViewModel
    {
        [Required(ErrorMessage = "Fill in category name")]
        [Display(Name = "Name")]
        public string CategoryName { get; set; }

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
