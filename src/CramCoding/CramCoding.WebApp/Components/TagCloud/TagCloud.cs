using CramCoding.Data.Repositories;
using CramCoding.WebApp.ViewModels.ViewComponents.TagCloud;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CramCoding.WebApp.Components.TagCloud
{
    public class TagCloud : ViewComponent
    {
        private readonly ITagRepository tagRepository;

        public TagCloud(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new TagCloudViewModel()
            {
                Header = "Tagi",
                Tags = this.tagRepository.GetAll().Select(t => t.Name).ToArray()
            };
            return View(viewModel);
        }
    }
}
