using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CramCoding.WebApp.ViewModels
{
    public class EditPostViewModel
    {
        [Required(ErrorMessage = "Uzupełnij tytuł")]
        [Display(Name = "Tytuł")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Uzupełnij treść")]
        [Display(Name = "Treść")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Wybierz autora")]
        [Display(Name = "Autor")]
        public string SelectedAuthor { get; set; }

        public SelectListItem[] Authors { get; set; }

        [Required(ErrorMessage = "Wybierz kategorię")]
        [Display(Name = "Kategoria")]
        public string SelectedCategory { get; set; }

        public SelectListItem[] Categories { get; set; }

        [Required(ErrorMessage = "Wybierz tagi")]
        [Display(Name = "Tagi")]
        public string[] SelectedTags { get; set; }

        public SelectListItem[] Tags { get; set; }

        [Required(ErrorMessage = "Podaj datę publikacji")]
        [Display(Name = "Data publikacji")]
        public string PublishedDate { get; set; }

        [Required(ErrorMessage = "Podaj czas publikacji")]
        [Display(Name = "Czas publikacji")]
        public string PublishedTime { get; set; }

        [Display(Name = "Pokaż wpis")]
        public bool IsVisible { get; set; }
    }
}
