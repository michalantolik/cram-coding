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
                    Name = "Maximus",
                    Children = new List<Category>
                    {
                        new Category { Name = "Lorem" },
                        new Category { Name = "Vestibulum" },
                    }
                },
                new Category
                {
                    Name = "Libero",
                    Children = new List<Category>
                    {
                        new Category { Name = "Morbi" },
                        new Category { Name = "Proin" },
                        new Category { Name = "Cras" },
                    }
                },
            };
        }
    }
}
