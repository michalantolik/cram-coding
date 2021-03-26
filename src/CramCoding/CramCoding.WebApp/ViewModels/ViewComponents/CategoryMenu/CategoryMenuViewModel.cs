using AutoMapper;
using CramCoding.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CramCoding.WebApp.ViewModels.ViewComponents.CategoryMenu
{
    public class CategoryMenuViewModel
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public CategoryMenuViewModel(IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;

            Initialize();
        }

        private void Initialize()
        {
            var mainCategories = this.categoryRepository
                .GetAll(true)
                .Where(category => category.Parent == null)
                .ToArray();

            var mainCategoriesViewModels = mainCategories
                .Select(mainCategory =>
                {
                    mainCategory.Children = mainCategory.Children.OrderBy(child => child.Name).ToArray();
                    return this.mapper.Map<CategoryViewModel>(mainCategory);
                })
                .ToArray();

            Categories = mainCategoriesViewModels;
        }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
