using AutoMapper;
using CramCoding.Data.Repositories;
using CramCoding.WebApp.ViewModels.ViewComponents.CategoryMenu;
using Microsoft.AspNetCore.Mvc;

namespace CramCoding.WebApp.Components.CategoryMenu
{
    public class CategoryMenu : ViewComponent
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public CategoryMenu(
            IMapper mapper,
            ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new CategoryMenuViewModel(this.mapper, this.categoryRepository);
            return View(viewModel);
        }
    }
}
