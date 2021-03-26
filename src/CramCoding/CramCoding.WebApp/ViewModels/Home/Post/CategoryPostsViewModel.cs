using CramCoding.WebApp.ViewModels.Admin.Post;
using System.Collections.Generic;

namespace CramCoding.WebApp.ViewModels.Home.Post
{
    public class CategoryPostsViewModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
