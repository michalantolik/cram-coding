using CramCoding.Domain.Entities;
using System.Linq;

namespace CramCoding.Data.Seed
{
    public class TagsSeederData
    {
        public readonly Tag[] Tags;

        public TagsSeederData()
        {
            var tagNames = new string[]
            {
                "magna",
                "enim",
                "tincidunt",
                "blandit",
                "vestibulum",
                "primis",
                "ultrices",
                "elementum",
                "placerat",
                "metus",
                "lacinia",
                "luctus",
                "finibus",
                "tempor",
                "interdum",
                "commodo",
                "suspendisse",
                "ante",
                "maximus",
                "bibendum",
                "gravida",
                "scelerisque",
                "turpis",
                "imperdiet",
                "gravida",
                "rutrum",
                "pellentesque",
                "consectetur",
                "volutpat",
                "rutrum",
                "pharetra",
                "aliquam",
                "turpis",
            };

            Tags = tagNames.Select(n => new Tag { Name = n }).ToArray();
        }
    }
}
