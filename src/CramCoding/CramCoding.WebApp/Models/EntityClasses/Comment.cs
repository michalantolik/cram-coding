using System.ComponentModel.DataAnnotations;

namespace CramCoding.WebApp.Models.EntityClasses
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public Post Post { get; set; }

        [Required]
        public ApplicationUser Author { get; set; }
    }
}
