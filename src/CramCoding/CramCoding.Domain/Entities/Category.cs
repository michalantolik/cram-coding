using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CramCoding.Domain.Entities
{
    public class Category
    {

        #region Constructor

        public Category()
        {
            Children = new List<Category>();
            Posts = new List<Post>();
        }

        #endregion


        #region Own properties

        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        #endregion Own properties


        #region Navigation properties

        public Category Parent { get; set; }

        public ICollection<Category> Children { get; set; }

        public ICollection<Post> Posts { get; set; }

        #endregion
    }
}
