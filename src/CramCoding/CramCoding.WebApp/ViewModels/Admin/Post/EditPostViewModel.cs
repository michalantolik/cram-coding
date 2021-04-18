using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace CramCoding.WebApp.ViewModels.Admin.Post
{
    public class EditPostViewModel
    {
        [Required(ErrorMessage = "Fill in the header")]
        [Display(Name = "Header")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Fill in the content")]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Fill in the author")]
        [Display(Name = "Author")]
        public string SelectedAuthor { get; set; }

        public SelectListItem[] Authors { get; set; }

        [Required(ErrorMessage = "Fill in the category")]
        [Display(Name = "Category")]
        public string SelectedCategory { get; set; }

        public SelectListItem[] Categories { get; set; }

        [Required(ErrorMessage = "Select tags")]
        [Display(Name = "Tags")]
        public string[] SelectedTags { get; set; }

        public SelectListItem[] Tags { get; set; }

        [Required(ErrorMessage = "Fill in publish date")]
        [Display(Name = "Publish date")]
        public DateTimeOffset? PublishedDate { get; set; }

        [Required(ErrorMessage = "Fill in publish time")]
        [Display(Name = "Public time")]
        public DateTimeOffset? PublishedTime { get; set; }

        [Display(Name = "Publicly visible")]
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
