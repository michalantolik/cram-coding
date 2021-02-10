using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CramCoding.WebApp.Models.EntityClasses
{
    /// <summary>
    /// Blog post
    /// </summary>
    public class Post
    {
        #region Constructor

        public Post()
        {
            CreatedAt = DateTimeOffset.Now;
            UpdatedAt = DateTimeOffset.Now;
            PublishedAt = DateTimeOffset.Now;

            Categories = new List<Category>();
            Tags = new List<Tag>();
        }

        #endregion Constructor


        #region Own properties

        [Key]
        public int PostId { get; set; }

        [Required]
        [StringLength(150)]
        public string Header
        {
            get 
            { 
                return header;
            }
            set
            { 
                header = value;

            }
        }
        private string header;

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        public DateTimeOffset UpdatedAt { get; set; }

        [Required]
        public DateTimeOffset PublishedAt { get; set; }

        [Required]
        public bool IsVisible { get; set; }

        [Required]
        public int ViewsCount { get; set; }

        #endregion Own properties


        #region Navigation properties

        [Required]
        public ApplicationUser Author { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Tag> Tags { get; set; }

        #endregion Navigation properties


        #region Unmapped properties

        [NotMapped]
        public string Slug
        {
            get
            {
                if (String.IsNullOrWhiteSpace(Header))
                {
                    throw new InvalidOperationException(
                        $"Cannot create {nameof(Slug)} because {nameof(Header)} is null or whitespace");
                }
                var headerSlug = Header.ToLowerInvariant().Trim().Replace(" - ", "-").Replace(" ", "-");
                var slug = $"posts/{headerSlug}";

                return slug;
            }
        }

        #endregion Unmapped properties
    }
}
