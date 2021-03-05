using CramCoding.Domain.Entities;
using System.Collections.Generic;

namespace CramCoding.Data.Seed
{
    public class CategorySeederData
    {
        internal readonly Category[] Categories;

        internal CategorySeederData()
        {
            Categories = new Category[]
            {
                new Category
                {
                    Name = "Lorem",
                    Children = new List<Category>
                    {
                        new Category { Name = "Vivamus" },
                        new Category { Name = "Pellentesque" },
                        new Category { Name = "Etiam" },
                    }
                },
                new Category
                {
                    Name = "Ipsum",
                    Children = new List<Category>
                    {
                        new Category { Name = "Nulla" },
                        new Category { Name = "Curabitur" },
                        new Category { Name = "Aliquam" },
                    }
                },
            };
        }
    }
}
