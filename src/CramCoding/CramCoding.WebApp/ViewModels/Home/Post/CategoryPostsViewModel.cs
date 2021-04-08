using System.Collections.Generic;

namespace CramCoding.WebApp.ViewModels.Home.Post
{
    public class CategoryPostsViewModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<HomePostViewModel> Posts { get; set; }
    }
}
