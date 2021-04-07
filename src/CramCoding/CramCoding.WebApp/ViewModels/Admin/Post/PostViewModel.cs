using System;

namespace CramCoding.WebApp.ViewModels.Admin.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset PublishedAt { get; set; }
        public bool IsVisible { get; set; }
        public int ViewsCount { get; set; }
        public string Author { get; set; }
        public string[] Categories { get; set; }
        public string[] Tags { get; set; }
        public int CommentsCount { get; set; }
    }
}
