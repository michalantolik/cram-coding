using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CramCoding.Domain.Entities
{
    public class Tag
    {
        public Tag()
        {
            Posts = new List<Post>();
        }

        [Key]
        public int TagId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
