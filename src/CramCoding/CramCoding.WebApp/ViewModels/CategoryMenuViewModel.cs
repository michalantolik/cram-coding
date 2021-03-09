using AutoMapper;
using CramCoding.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CramCoding.WebApp.ViewModels
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
            var mainCategories = this.categoryRepository.GetAll(true).Where(c => c.Parent == null).ToArray();
            var categoriesViewModels = mainCategories.Select(c => this.mapper.Map<CategoryViewModel>(c)).ToArray();

            Categories = categoriesViewModels;
        }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
