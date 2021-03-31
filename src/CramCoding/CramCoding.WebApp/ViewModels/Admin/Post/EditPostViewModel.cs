using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace CramCoding.WebApp.ViewModels.Admin.Post
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
        public DateTimeOffset? PublishedDate { get; set; }

        [Required(ErrorMessage = "Podaj czas publikacji")]
        [Display(Name = "Czas publikacji")]
        public DateTimeOffset? PublishedTime { get; set; }

        [Display(Name = "Pokaż wpis")]
        public bool IsVisible { get; set; }

        /// <summary>
        /// Form submission datetime (UTC) as captured JS script on the client side into a hidden form field
        /// </summary>
        public DateTimeOffset? FormSumbissionDateTimeUtc { get; set; }

        /// <summary>
        /// Returns merged date and time information from <see cref="PublishedDate"/> and <see cref="PublishedTime"/>
        /// </summary>
        /// <remarks>Returns UTC datetime information</remarks>
        public DateTimeOffset? PublishedDateTimeUtc
        {
            get
            {
                if (PublishedDate == null || PublishedTime == null)
                {
                    return null;
                }

                if (PublishedDate.Value.Offset != PublishedTime.Value.Offset)
                {
                    return null;
                }

                var publishedDateTime = new DateTimeOffset(
                    PublishedDate.Value.Year,
                    PublishedDate.Value.Month,
                    PublishedDate.Value.Day,
                    PublishedTime.Value.Hour,
                    PublishedTime.Value.Minute,
                    PublishedTime.Value.Second,
                    PublishedTime.Value.Millisecond,
                    PublishedTime.Value.Offset
                );

                return publishedDateTime.ToUniversalTime();
            }
        }
    }
}
