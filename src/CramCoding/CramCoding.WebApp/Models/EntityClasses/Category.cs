﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CramCoding.WebApp.Models.EntityClasses
{
    public class Category
    {
        public Category()
        {
            Posts = new List<Post>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }

    }
}