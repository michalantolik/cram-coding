using System.Collections.Generic;

namespace CramCoding.WebApp.ViewModels
{
    public class CategoryPostsViewModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
